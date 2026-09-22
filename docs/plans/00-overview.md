# Scryfall client remediation: overview and hand-off notes

Written 2026-09-22 after a full review of the repository against the current
Scryfall API docs (https://scryfall.com/docs/api) and live API responses.
Three independent plans live next to this file. Each one is self-contained and
written for an agent starting with no prior context.

| Plan | File | Depends on | Can run in parallel with |
|------|------|------------|--------------------------|
| 1. Transport, errors, rate limiting | `01-transport-errors-ratelimit.md` | nothing | Plan 2 |
| 2. API model drift and new endpoints | `02-api-drift-and-endpoints.md` | nothing (one optional hook into Plan 1) | Plan 1 |
| 3. Packaging, CI, dependencies, tests | `03-packaging-ci-tests.md` | Plans 1 and 2 merged | nothing (run last) |

Recommended order: start Plans 1 and 2 on separate branches at the same time,
merge both, then run Plan 3.

## Ground rules for every plan

- Work on a feature branch off `main`, never directly on `main`. The repo's
  history uses short-lived branches merged through pull requests.
- Do not bump the package version. Plan 3 bumps it to `2.0.0` once, because
  Plans 1 and 2 both contain breaking changes.
- The library uses Newtonsoft.Json. Do not introduce System.Text.Json.
- Keep the existing public surface where the plan does not say otherwise.
  Where a plan says "breaking", that is accepted and will be released as 2.0.
- Build and test commands (run from `src/`):

```bash
export DOTNET_NUGET_SIGNATURE_VERIFICATION=false   # needed until Plan 3 removes Splat 19.3.1, whose signing cert is revoked
dotnet build HelpfulThings.Connect.Scryfall.sln -c Release
dotnet test HelpfulThings.Connect.Scryfall.Tests.Live -c Release --no-build
```

- The live test project hits api.scryfall.com. Before your changes, 15 of 33
  live tests already fail because of brittle expectations (prices, affiliate
  URL hosts, image timestamps, casing). Do not try to make those pass in Plans
  1 or 2; Plan 3 rewrites them. Only make sure the test project still compiles
  and that the tests relevant to your plan pass.
- Scryfall requires a `User-Agent` and `Accept` header on every request. The
  static `HttpClient` in `BaseApiClient` already sets both. Keep that.
- Rate limits (https://scryfall.com/docs/api/rate-limits): `/cards/search`,
  `/cards/named`, `/cards/random`, `/cards/collection` are 2 requests/second
  (500 ms). `/cards/manifest` is 10 requests/minute (6,000 ms). Everything
  else is 10/second (100 ms). Any ad-hoc `curl` you run while working must
  respect this.

## Layout of the code

```
src/HelpfulThings.Connect.Scryfall/
  Clients/ApiClients/BaseApiClient.cs      shared HttpClient, throttling, JSON decode, exception wrapping
  Clients/ApiClients/*Client.cs            one class per API area (Cards, Sets, Rulings, Catalog, Symbology, BulkData)
  Clients/ScryfallApiClient.cs             aggregates the clients, implements IScryfallApiClient, paginates lists
  Clients/ScryfallIoClient.cs              unthrottled downloader for *.scryfall.io bulk files
  Models/                                  POCOs with [JsonProperty] attributes
  Enums/                                   enums with [EnumMember] values, read via EnumExtensions.GetEnumValue()
  Identifiers/                             request identifiers for POST /cards/collection
  Converters/                              Newtonsoft converters
  RequestResponse/                         ScryfallList<T>, ScryfallCatalog, CollectionRequest/Response
  ServiceCollectionExtensions.cs           AddScryfallApi() for Microsoft DI, plus a Splat helper
src/HelpfulThings.Connect.Scryfall.Tests.Live/   NUnit + FluentAssertions tests against the real API
```
