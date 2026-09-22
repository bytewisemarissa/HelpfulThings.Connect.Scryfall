# Plan 1: Transport, error handling and rate limiting

Read `00-overview.md` first. Branch name suggestion: `transport-errors-ratelimit`.

## Goal

Make the HTTP layer honest and correct: surface Scryfall's own error objects,
stop mangling search queries, throttle per endpoint at the documented rates,
and clean up the bulk-file downloader. No model changes to `Card`, `Set`, etc.
(those are Plan 2).

## Verified facts you can rely on

- `HttpUtility.HtmlEncode` is applied to the `q` parameter in
  `CardsClient.SearchAsync`, `AutoCompleteAsync`, `RandomAsync` and
  `RandomImageAsync`. `QueryHelpers.AddQueryString` already URL-encodes.
  Live check: `q=o:"draw a card"` returns 2,572 cards; the HTML-encoded form
  `o:&quot;draw a card&quot;` returns a 404 error object. Remove the HTML encode.
- `BaseApiClient.MakeDelayedRequestAsync` calls `EnsureSuccessStatusCode()`,
  so the JSON error body is thrown away. Every failure reaches the caller as
  `ScryfallException("There was a problem connecting to the Scryfall API...")`
  wrapping an `HttpRequestException`. A 404 for an unknown card name, a 422
  for a missing back face, and a 429 rate limit are indistinguishable.
- Scryfall error object (https://scryfall.com/docs/api/errors):
  `object` ("error"), `status` (int), `code` (string), `details` (string),
  `type` (string, nullable), `warnings` (string array, nullable).
  Example live body for `GET /cards/nope/nope`:
  `{"object":"error","code":"not_found","status":404,"details":"No card found with the given ID or set code and collector number."}`
- Current throttle: a static kernel `Semaphore(1,1)`, blocking `WaitOne()`
  inside an async method, released by a fire-and-forget `Task.Run` after a
  100 ms `Task.Delay`. The `System.Threading.RateLimiting` package is
  referenced in the csproj but never used.
- Documented limits: 500 ms for search/named/random/collection, 6,000 ms for
  `/cards/manifest`, 100 ms for everything else. Receiving a 429 limits access
  for 30 seconds; ignoring 429s can get an application banned.
- Boolean query parameters are sent as `True`/`False` (from `bool.ToString()`).
  The API accepts them, but the docs show lowercase. Send lowercase.
- `ScryfallIoClient.MakeNonMeteredRequest` allocates a 15,000,000 byte buffer
  per call, never calls `EnsureSuccessStatusCode`, never sets
  `ScryfallIoProgress.TotalBytes`, has a private unused `Percentage` property
  that would divide by zero, and its host check is
  `uri.Host.Contains("scryfall.io")`, which also matches `notscryfall.io`.

## Steps

### 1. Add an error model and a typed exception

- New `Models/ScryfallError.cs` mapping the six fields above with
  `[JsonProperty]` attributes. `Type` is `string?`, `Warnings` is `string[]?`.
- Keep `ScryfallException` as the base type (public API). Add a constructor
  `ScryfallException(string message)` so it can be thrown without an inner
  exception.
- New `ScryfallApiException : ScryfallException` with properties
  `HttpStatusCode StatusCode`, `ScryfallError? Error`, and the raw body as
  `string? ResponseBody`. Message should include status and `Error.Details`
  when present, for example `Scryfall returned 404 (not_found): No card found...`.
- Optional but useful: `ScryfallRateLimitException : ScryfallApiException`
  thrown for status 429, carrying `TimeSpan? RetryAfter` parsed from the
  `Retry-After` header when present.

### 2. Rewrite `BaseApiClient` request handling

- Replace `EnsureSuccessStatusCode()` with: read the body as string; if the
  status is not success, try to deserialize `ScryfallError` (guard with
  try/catch because 5xx bodies may be HTML) and throw the typed exception.
- Only wrap genuine transport failures (`HttpRequestException`,
  `TaskCanceledException`, `JsonException`) in `ScryfallException`. Do not
  catch and re-wrap `ScryfallApiException` or `ArgumentException`.
- Apply the same handling in `MakeDelayedRequestImageAsync`. Image endpoints
  return a JSON error body on 404/422 with a JSON content type, so check
  `response.IsSuccessStatusCode` before returning the stream.
- Add `CancellationToken cancellationToken = default` as the last parameter of
  both helpers and thread it through every client method. This is additive
  and not breaking because all new parameters have defaults.

### 3. Replace the throttle with a per-endpoint minimum-interval limiter

- Add `enum RateLimitCategory { Default, CardSearch, Manifest }` (internal is
  fine) with intervals 100 ms, 500 ms, 6,000 ms.
- Implement a small `internal static class RequestThrottle` holding, per
  category, a `SemaphoreSlim(1,1)` and the timestamp of the last request sent
  (`Stopwatch.GetTimestamp()` based). Algorithm inside the semaphore:
  compute `remaining = interval - (now - lastSent)`; if positive,
  `await Task.Delay(remaining, ct)`; send the request; record `lastSent`;
  release in `finally`. No fire-and-forget tasks, no blocking waits.
- Scryfall also documents a global cap of 10/second. Simplest way to honor it:
  in addition to the per-category gate, take a `Default` gate around every
  request too (nested: category gate first, then default gate). This keeps all
  traffic at or below 10/second and search-class traffic at or below 2/second.
- `MakeDelayedRequestAsync<T>` and the image variant take the category as a
  parameter (default `RateLimitCategory.Default`). Pass `CardSearch` from
  `SearchAsync`, `NamedAsync`, `NamedImageAsync`, `RandomAsync`,
  `RandomImageAsync`, `CollectionAsync`. Plan 2 will pass `Manifest` from the
  new manifest method; if Plan 2 has already merged when you get here, wire it.
- Remove the `System.Threading.RateLimiting` package reference unless you
  decide to build the limiter on it. Either is acceptable; the min-interval
  approach above is simpler and matches the docs exactly.
- Rework `DelayedRequestTest` in the live test project so it asserts that two
  consecutive `SearchAsync` calls are at least 500 ms apart and two consecutive
  `CardByScryfallIdAsync` calls are at least 100 ms apart. Today it measures
  and asserts nothing.

### 4. Fix query building in `CardsClient`

- Remove every `HttpUtility.HtmlEncode(...)` call and the `System.Web` using.
- Send booleans as `"true"`/`"false"`.
- `NamedAsync` and `NamedImageAsync`: when both `exact` and `fuzzy` are null,
  throw `ArgumentException` before entering the throttled request. Today it is
  a `NullReferenceException` wrapped as a connection failure.
- `CardBySetCollectorNumberAsync` and its image variant build
  `cards/{set}/{number}/` with a trailing slash when no language is given. The
  API tolerates it but build the path without the trailing segment.

### 5. Fix `ScryfallApiClient.GetNextPageOfListResponseAsync`

Move the `HasMore` and `NextPage` checks outside the throttled lambda and
throw `ArgumentException` directly. Keep using `NextPage.PathAndQuery` against
the base address; that works.

### 6. Clean up `ScryfallIoClient`

- Host check: accept only `scryfall.io` or hosts ending in `.scryfall.io`.
- Call `EnsureSuccessStatusCode()` (or throw `ScryfallApiException` for
  consistency) before streaming.
- Use an 81,920 byte buffer (or `ArrayPool<byte>`), pass the cancellation
  token to `GetAsync`, use `await using` for the streams.
- Set `TotalBytes` from `response.Content.Headers.ContentLength ?? 0` on every
  progress report. Make `Percentage` a public read-only property that returns
  `null` (or 0) when `TotalBytes` is 0.
- `IProgress<T>` parameter should be nullable (`IProgress<...>? progress`);
  the code already null-checks it.

### 7. HttpClient hygiene in `BaseApiClient`

- Construct the static client with a `SocketsHttpHandler
  { PooledConnectionLifetime = TimeSpan.FromMinutes(15) }` so DNS changes are
  picked up.
- Default `User-Agent` should include the assembly version, for example
  `HelpfulThings-Connect-Scryfall/2.0.0`. Keep `UpdateUserAgent` as is; the
  docs say applications must identify themselves, so document in the README
  that consumers should call it.

## Verification

- Build succeeds with zero warnings introduced.
- Live: `SearchAsync("o:\"draw a card\" t:instant")` returns `TotalCards > 0`.
- Live: `NamedAsync("Definitely Not A Card", null, null)` throws
  `ScryfallApiException` with `StatusCode == NotFound` and
  `Error.Code == "not_found"`.
- Live: `NamedImageAsync("Lightning Bolt", null, null, CardFaces.Back, ...)`
  throws `ScryfallApiException` with status 422 (no back face).
- `NamedAsync(null, null, null)` throws `ArgumentException` synchronously or
  as the task's exception, not `ScryfallException`.
- The reworked `DelayedRequestTest` passes.
- Add these as tests in `Tests.Live/Clients/CardsClientTests.cs` (or a new
  `ErrorHandlingTests.cs`).

## Out of scope

Model fields, bulk data model, new endpoints (Plan 2). Package metadata,
Splat, CI, rewriting the brittle equivalence tests (Plan 3).
