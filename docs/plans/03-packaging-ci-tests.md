# Plan 3: Packaging, CI, dependencies, and tests

Read `00-overview.md` first. Run this plan only after Plans 1 and 2 are merged
into `main`. Branch name suggestion: `release-2.0-prep`.

## Goal

Make the package installable and buildable from a clean clone, make CI honest,
replace the brittle live tests with stable ones plus an offline unit test
project, and document the 2.0 breaking changes.

## Verified facts you can rely on

- Restoring the solution on a machine with NuGet signature verification on
  fails with `NU3012: Package 'Splat 19.3.1' ... certificate revoked` for
  `Splat`, `Splat.Core`, `Splat.Builder`, `Splat.Logging`. Splat versions up to
  21.0.0 exist on nuget.org. Splat is used only by
  `ServiceCollectionExtensions.RegisterWithSplat`.
- `src/HelpfulThings.Connect.Scryfall/HelpfulThings.Connect.Scryfall.csproj`
  contains `<PackageLicense>MIT</PackageLicense>`, which is not an MSBuild or
  NuGet property. The published package has no license metadata. The correct
  property is `<PackageLicenseExpression>MIT</PackageLicenseExpression>`.
  `<Copyright>2023</Copyright>` is stale. `<Version>` is `1.7.1`.
- Both workflows in `.github/workflows/` install `dotnet-version: 8.0.x` while
  the projects target `net10.0` and `src/global.json` pins SDK `10.0.0`
  (`rollForward: latestMajor`). Builds pass only because the `ubuntu-latest`
  image happens to preinstall .NET 10.
- Tracked files that should not be: `src/.idea/**` (4 files),
  `src/HelpfulThings.Connect.Scryfall/.idea/**` (3 files), and
  `src/HelpfulThings.Connect.Scryfall.sln.DotSettings.user`. `src/.gitignore`
  already ignores `*.user` but not `.idea/`.
- Live test results before any plan: 18 pass, 15 fail. Failures are all
  `Should().BeEquivalentTo(wholeObject)` comparisons against hard-coded data
  that drifts: daily prices, affiliate hosts (`tcgplayer.pxf.io` became
  `partner.tcgplayer.com`), image URL cache-buster timestamps, set icon
  timestamps, and casing left over from when these were enums (`"Core"` vs
  `"core"`, `"Rare"` vs `"rare"`, `"NonFoil"` vs `"nonfoil"`, `"Normal"` vs
  `"normal"`, `"Oval"` vs `"oval"`).
- `SymbologyClientTests.ParseMana` assigns to `results.Colorless`,
  `MonoColor`, `MultiColored` instead of asserting on them.
- `LiveTestThrottlingFixture` (100 ms sleep in TearDown) is inherited only by
  `SetsClientTests`. After Plan 1 the client throttles itself, so the fixture
  is redundant.
- `Constants.Localhost` is a mutable `public static string`.

## Steps

### 1. Dependencies

- Remove the Splat package and `RegisterWithSplat`. Add a README note showing
  the one-line Splat registration consumers can write themselves
  (`Locator.CurrentMutable.Register<IScryfallApiClient>(() => new ScryfallApiClient());`).
  If the maintainer prefers to keep it, the fallback is upgrading to
  `Splat` 21.0.0 and confirming restore works with signature verification on.
- Remove `System.Threading.RateLimiting` if Plan 1 did not use it.
- Confirm `dotnet restore` succeeds without
  `DOTNET_NUGET_SIGNATURE_VERIFICATION=false`.
- In `ServiceCollectionExtensions.AddScryfallApi`, register the clients as
  singletons. They are stateless wrappers over one static `HttpClient`.

### 2. Package metadata (`HelpfulThings.Connect.Scryfall.csproj`)

- `<Version>2.0.0</Version>`.
- Replace `PackageLicense` with `PackageLicenseExpression` = `MIT`.
- `<Copyright>2023-2026 Marissa Sherman</Copyright>`.
- Add `<PackageReadmeFile>README.md</PackageReadmeFile>` and pack the root
  `README.md` (`<None Include="..\..\README.md" Pack="true" PackagePath="\" />`).
- Add `<PackageTags>scryfall;mtg;magic</PackageTags>` and
  `<PackageReleaseNotes>` pointing at the changelog section in the README.
- Run `dotnet pack -c Release` and inspect the `.nuspec` inside the `.nupkg`
  to confirm license, readme and icon are present.

### 3. CI workflows

- `build.yml` and `build-and-push-nuget.yml`: `dotnet-version: 10.0.x`.
- `build.yml`: add a step that runs the new offline unit test project (step 5)
  on every push. Do not run the live tests in CI by default; add a separate
  manually triggered (`workflow_dispatch`) job, or a nightly schedule, for
  the live suite.
- Add `actions/cache` for NuGet packages (optional).

### 4. Repository hygiene

- `git rm -r --cached src/.idea src/HelpfulThings.Connect.Scryfall/.idea src/HelpfulThings.Connect.Scryfall.sln.DotSettings.user`
- Add `.idea/` to `src/.gitignore`.
- Make `Constants.Localhost` a `const`, or remove it if Plan 2 eliminated the
  remaining localhost defaults.
- Delete `docs/plans/` once all three plans are merged, or keep it as a
  changelog source; maintainer's call. Mention it in the PR description.

### 5. Offline unit test project

Create `src/HelpfulThings.Connect.Scryfall.Tests` (NUnit, same package
versions as the live project, no network). Purpose: lock in deserialization
behaviour against recorded JSON so model regressions are caught in CI.

- Add a `Fixtures/` folder with real responses saved from the API (fetch each
  once, respecting rate limits, and commit the JSON as embedded resources or
  copy-to-output content):
  `card-lightning-bolt.json` (single face, `all_parts` present, no
  `security_stamp`), `card-delver-of-secrets.json` (transform, `card_faces`,
  `preview`), `card-reversible.json` (no top-level `oracle_id`),
  `set-mh3.json`, `bulk-data-list.json`, `symbology.json`,
  `error-not-found.json`, `collection-response-with-not-found.json`,
  `migrations-list.json`.
- Tests: each fixture deserializes into its model with no exception; spot
  assertions on the fields Plan 2 changed (preview, nullable image URIs,
  `SecurityStamp == null`, `OracleId == null` for reversible, legalities
  extension data retaining unknown formats, bulk `JsonlDownloadUri`,
  `CompressedSize`).
- Tests for `IdentifierConverter` round-trip (serialize a `CollectionRequest`
  with every identifier type, deserialize the `not_found` echo).
- Tests for `EnumExtensions.GetEnumValue` on every enum (every member has a
  non-empty `EnumMember` value).
- Tests for the throttle from Plan 1 using a fake clock or by measuring two
  back-to-back calls through a stubbed `HttpMessageHandler`.
- Tests for error mapping: a stubbed handler returning 404 with the recorded
  error body produces `ScryfallApiException` with the expected `Error.Code`.
  This requires `BaseApiClient` to accept an injectable `HttpMessageHandler`
  or `HttpClient` for tests; add an `internal` constructor plus
  `[InternalsVisibleTo("HelpfulThings.Connect.Scryfall.Tests")]`.

### 6. Rewrite the live tests

Principle: live tests prove the endpoint is reachable and the response maps
to the model. They must not assert on anything that changes daily.

- Replace every `Should().BeEquivalentTo(TestCards.X)` with assertions on
  stable identity fields only: `ScryfallId`, `OracleId`, `Name`, `SetCode`,
  `CollectorNumber`, `Layout`, `Rarity`, `ReleasedAt`, `ArtistName`,
  `MultiverseIds`, `MtgoId`, `TcgPlayerId`, `CardmarketId`. Add a shared
  helper such as `AssertIsBlackLotusAlpha(card)`.
- Shrink `TestData/TestCards.cs` and `TestSets.cs` to those stable fields.
  Fix casing to match the API (`"core"`, `"rare"`, `"normal"`, `"nonfoil"`).
- Set tests: assert `Code`, `ScryfallId`, `Name`, `SetType`, `ReleasedAt`,
  `TcgPlayerId`; do not assert `IconSvgUri` or `CardCount`.
- Symbology `ParseMana`: change the three assignments to `.Should().Be(...)`.
- Rulings tests: fine as they are once `HostedType` is removed (Plan 2);
  ruling text is stable.
- Delete `LiveTestThrottlingFixture` (Plan 1 throttles in the client).
- Uncomment and fix the Arena and MTGO tests using a card that has those IDs
  (Black Lotus has an MTGO ID but no Arena ID; pick a recent Standard card for
  Arena, for example look up `cards/named?exact=Llanowar Elves` and take the
  `arena_id` from the newest printing).
- Add `[Category("Live")]` to every live fixture so the suite can be filtered.
- Result: the entire live suite passes against the real API at the time of the
  PR. Record the pass count in the PR description.

### 7. README

- Add a "Breaking changes in 2.0" section listing: typed exceptions and the
  error model, nullable `ImageUris`, `PurchaseUris`, `OracleId`,
  `SecurityStamp`, the bulk data field renames and JSONL format, `preview`
  becoming an object, `HostedType` removal, Splat removal, singleton
  registration.
- Document per-endpoint throttling and that 429 surfaces as an exception the
  caller must back off on.
- Document `BaseApiClient.UpdateUserAgent` and quote Scryfall's requirement
  that the User-Agent name the consuming application.
- Add a short "Running the tests" section (offline vs live).

## Verification

- `dotnet restore` with default NuGet settings succeeds on a clean clone.
- `dotnet build` and the offline unit tests pass; `build.yml` runs them.
- The live suite passes in full.
- `dotnet pack` output contains license expression, readme, and icon.
- `git ls-files | grep -E '\.idea|\.user$'` prints nothing.
