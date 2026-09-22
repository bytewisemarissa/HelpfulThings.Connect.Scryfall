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

### Identifying your application

Scryfall's API guidelines require every application to identify itself with a descriptive `User-Agent` header. This library sets a default `User-Agent`, but consumers should call `BaseApiClient.UpdateUserAgent(...)` at startup with their own application name and version, for example:

```c#
using System.Net.Http.Headers;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;

BaseApiClient.UpdateUserAgent(new ProductInfoHeaderValue("MyApplication", "1.0.0"));
```

### Error handling

Requests that fail against the Scryfall API throw `ScryfallApiException`, which carries the HTTP status code and, when Scryfall returns one, the parsed `ScryfallError` object (`Code`, `Details`, `Type`, `Warnings`). A 429 response throws the more specific `ScryfallRateLimitException`, which also exposes `RetryAfter` when Scryfall sends a `Retry-After` header. Genuine transport failures (DNS, timeouts, connection resets) still throw the base `ScryfallException`.