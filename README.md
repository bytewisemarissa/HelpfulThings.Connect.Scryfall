# HelpfulThings.Connect.Scryfall

## A .NET library for working with Scryfall

This is not an official Scryfall package.

### Setup

Make sure you have the package installed and you are pretty much already there. This library is designed to support dependency injection. So, depending on the type of host builder you are using it's as easy as this:

#### Host Builder

```c#
using HelpfulThings.Connect.Scryfall;

var host = new HostBuilder()
    .ConfigureServices(services =>
    {
    	services.AddScryfallApi();
    })
    .Build();
```

#### Web Builder

```c#
using HelpfulThings.Connect.Scryfall;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScryfallApi();
var app = builder.Build();
app.Run();
```

That's it you should be ready to go. `AddScryfallApi()` registers both clients as singletons, since they are stateless wrappers over one shared, throttled `HttpClient`.

If you use [Splat](https://github.com/reactiveui/splat) instead of `Microsoft.Extensions.DependencyInjection`, register the clients yourself with one line each:

```c#
using Splat;
using HelpfulThings.Connect.Scryfall.Clients;

Locator.CurrentMutable.RegisterLazySingleton<IScryfallApiClient>(() => new ScryfallApiClient());
Locator.CurrentMutable.RegisterLazySingleton<IScryfallIoClient>(() => new ScryfallIoClient());
```

### Usage

In general you will inject two interfaces. IScryfallApiClient and IScryfallIoClient. For the majority of uses cases you will leverage IScryfallApiClient. This client has all of the Scryfall functionality built into it. The various routes of the API are available as clients as members of the IScryfallApiClient. The client will manage throttling for you. If you need to follow a Scryfall IO url the IScryfallIoClient will allow you to do that without the rate limiting feature of IScryfallApiClient.

### Rate limiting

`IScryfallApiClient` throttles every request to stay within [Scryfall's documented rate limits](https://scryfall.com/docs/api/rate-limits): `cards/search`, `cards/named`, `cards/random`, and `cards/collection` are limited to 2 requests/second, `cards/manifest` to 10 requests/minute, and everything else to 10 requests/second. If Scryfall still responds with `429 Too Many Requests` — for example when multiple processes share one API key — the client throws `ScryfallRateLimitException`; callers must back off, optionally using its `RetryAfter` value, before retrying.

### Identifying your application

Scryfall's API guidelines require every application to identify itself with a descriptive `User-Agent` header. This library sets a default `User-Agent`, but consumers should call `BaseApiClient.UpdateUserAgent(...)` at startup with their own application name and version, for example:

```c#
using System.Net.Http.Headers;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;

BaseApiClient.UpdateUserAgent(new ProductInfoHeaderValue("MyApplication", "1.0.0"));
```

### Error handling

Requests that fail against the Scryfall API throw `ScryfallApiException`, which carries the HTTP status code and, when Scryfall returns one, the parsed `ScryfallError` object (`Code`, `Details`, `Type`, `Warnings`). A 429 response throws the more specific `ScryfallRateLimitException`, which also exposes `RetryAfter` when Scryfall sends a `Retry-After` header. Genuine transport failures (DNS, timeouts, connection resets) still throw the base `ScryfallException`.

### Downloading bulk data

Scryfall's bulk data files are gzip-compressed JSON Lines (`.jsonl.gz`) — one card object per line, rather than one big JSON array. Use `IScryfallApiClient.BulkData` to look up the download URI, and `IScryfallIoClient` to fetch the file itself without going through the API's rate limiter:

```c#
using System.IO.Compression;
using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

var listing = await scryfallApiClient.BulkData.GetBulkDataListingByTypeAsync(BulkTypes.OracleCards);

await using var destination = File.Create("oracle-cards.jsonl.gz");
await scryfallIoClient.MakeNonMeteredRequest(listing.JsonlDownloadUri, progress, destination);

await using var compressed = File.OpenRead("oracle-cards.jsonl.gz");
await using var decompressed = new GZipStream(compressed, CompressionMode.Decompress);
using var reader = new StreamReader(decompressed);

string? line;
while ((line = await reader.ReadLineAsync()) != null)
{
    var card = JsonConvert.DeserializeObject<Card>(line);
    // ... do something with card
}
```

### Breaking changes in 2.0

- Errors now throw typed exceptions instead of an unhandled deserialization failure or a generic
  HTTP exception: `ScryfallApiException` (status code + parsed `ScryfallError`) and, for 429
  responses, the more specific `ScryfallRateLimitException` (adds `RetryAfter`).
- `Card.ImageUris`, `Card.PurchaseUris`, `Card.OracleId`, and `Card.SecurityStamp` are now
  nullable. Double-faced and reversible cards may not carry these at the top level; check
  `Card.CardFaces` instead.
- `Card.Preview` is now an object (`CardPreview`: `Source`, `SourceUri`, `PreviewedAt`) rather than
  the previous flat fields.
- `BulkData` field names were corrected to match the API (`JsonlDownloadUri`, `CompressedSize`),
  and bulk files are now JSON Lines (`.jsonl.gz`, one card per line) rather than one large JSON
  array — see "Downloading bulk data" above.
- `HostedType` was removed; it did not correspond to anything in the API.
- The Splat integration (`ServiceCollectionExtensions.RegisterWithSplat`) was removed. See
  "Setup" above for the one-line replacement.
- `AddScryfallApi()` now registers `IScryfallApiClient` and `IScryfallIoClient` as singletons
  instead of scoped services.
- Requests are now throttled per Scryfall's documented, per-endpoint rate limits instead of a
  single fixed delay; see "Rate limiting" above.
- The package's NuGet metadata was corrected: a valid `PackageLicenseExpression` (MIT), a bundled
  `README.md`, and refreshed copyright and tags. This has no effect on the API surface.

### Running the tests

From `src/`:

```bash
# Offline: fixture-backed model and behavior tests, no network access. Runs in CI on every push.
dotnet test HelpfulThings.Connect.Scryfall.Tests

# Live: exercises the real api.scryfall.com. Respect the rate limits above if you also run
# ad-hoc requests against the API while these are running. Not run automatically on every push;
# trigger the "Test Build" workflow manually, or wait for its nightly schedule.
dotnet test HelpfulThings.Connect.Scryfall.Tests.Live --filter "Category=Live"
```
