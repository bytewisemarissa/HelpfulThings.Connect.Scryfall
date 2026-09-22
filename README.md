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

That's it you should be ready to go.

### Usage

In general you will inject two interfaces. IScryfallApiClient and IScryfallIoClient. For the majority of uses cases you will leverage IScryfallApiClient. This client has all of the Scryfall functionality built into it. The various routes of the API are available as clients as members of the IScryfallApiClient. The client will manage throttling for you. If you need to follow a Scryfall IO url the IScryfallIoClient will allow you to do that without the rate limiting feature of IScryfallApiClient.

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