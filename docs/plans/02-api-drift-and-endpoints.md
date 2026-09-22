# Plan 2: API model drift, bulk data, and new endpoints

Read `00-overview.md` first. Branch name suggestion: `api-drift`.

## Goal

Bring the models and enums back in line with the current Scryfall docs, fix
the bulk data client, and add the endpoints that have appeared since the
library was written. Breaking changes are accepted (2.0 release).

Doc pages to consult (all public, fetch as needed):
- Cards: https://scryfall.com/docs/api/cards
- Sets: https://scryfall.com/docs/api/sets
- Bulk data: https://scryfall.com/docs/api/bulk-data
- Card symbols: https://scryfall.com/docs/api/card-symbols
- Catalogs: https://scryfall.com/docs/api/catalogs
- Search parameters: https://scryfall.com/docs/api/cards/search
- Manifest: https://scryfall.com/docs/api/cards/manifest
- Migrations: https://scryfall.com/docs/api/migrations
- Tags: https://scryfall.com/docs/api/tags

## Verified facts you can rely on

- `GET /bulk-data` returns `{"object":"list","has_more":false,"data":[...]}`.
  `BulkDataClient.GetBulkDataListingAsync` deserializes into
  `IEnumerable<BulkData>` and therefore always throws
  `JsonSerializationException`. Reproduced.
- Bulk data objects today have exactly: `object, id, type, updated_at, uri,
  name, description, jsonl_download_uri, compressed_size`. The fields
  `download_uri`, `size`, `content_type`, `content_encoding` no longer exist.
  Files are gzipped JSON Lines (`.jsonl.gz`), one card object per line. Bulk
  types today: `oracle_cards, unique_artwork, default_cards, all_cards,
  rulings, art_tags, oracle_tags`.
- Card `preview` is a nested object: `{"source":"...","source_uri":"...","previewed_at":"2025-01-07"}`.
  The current `[JsonProperty("preview.previewed_at")]` attributes never match
  anything (Newtonsoft does not treat dots as paths). `source_uri` can be an
  empty string.
- Live card responses now include `resource_id` (string, nullable),
  `defense` (string, nullable), `game_changer` (bool), `image_updated_at`
  (ISO timestamp, present on every card but not yet in the docs table), and
  `prices.eur_etched`.
- `security_stamp` is nullable in the docs and absent on Black Lotus (lea/232)
  today. The model declares it `required string` (non-nullable).
- `oracle_id` is absent for the `reversible_card` layout (verified with
  "Adrix and Nev, Twincasters" from `q=is:reversible unique:prints`). The
  model declares `Guid`, not `Guid?`.
- `image_uris` and `purchase_uris` are documented nullable. Double-faced cards
  have no top-level `image_uris` (they are on each face). The model defaults
  these to objects full of `http://localhost` URIs, so a consumer reading
  `card.ImageUris.Normal` on Delver of Secrets gets `http://localhost/`.
- Live `legalities` keys today: alchemy, brawl, commander, competitivebrawl,
  duel, future, gladiator, historic, legacy, modern, oathbreaker, oldschool,
  pauper, paupercommander, penny, pioneer, predh, premodern, standard,
  standardbrawl, timeless, tlr, vintage. `competitivebrawl` and `tlr` are not
  in `FormatLegalities`.
- Card face docs list `artist_id` (UUID) and `defense`; the model has neither.
- Card symbol docs list `hybrid` and `phyrexian` booleans; the model has
  neither.
- Search `order` values now include `tix` and `eur`; `SortingOrders` lacks
  them. Catalogs `supertypes`, `card-types`, `battle-types`, `flavor-words`
  all return 200; `CatalogTypes` lacks them.
- `Converters/CardFaceConverter.cs` is referenced nowhere and, if it were
  applied, would only copy the object to itself. Delete it.
- `ScryfallList<T>.HostedType` carries the System.Text.Json `JsonIgnore`
  attribute, which Newtonsoft ignores.
- `IdentifierConverter.WriteJson` throws `NotImplementedException`, so
  serializing a `CollectionResponse` throws.

## Steps

### 1. Bulk data

- `Models/BulkData.cs`: remove `DownloadUri`, `Size`, `ContentType`,
  `ContentEncoding`. Add `JsonlDownloadUri` (`Uri`, `jsonl_download_uri`) and
  `CompressedSize` (`long`, `compressed_size`). Add `[JsonProperty("object")]
  string Object` only if you decide to add it everywhere (optional).
- `Enums/BulkTypes.cs`: add `ArtTags = "art_tags"`, `OracleTags = "oracle_tags"`.
- `BulkDataClient.GetBulkDataListingAsync` returns `ScryfallList<BulkData>`.
- Add `Tests.Live/Clients/BulkDataClientTests.cs`: listing returns 7+ items
  with non-localhost `JsonlDownloadUri` and `CompressedSize > 0`; by-type
  `OracleCards` and by-id round-trip work.
- README: update the bulk download example to say the file is `.jsonl.gz`
  and show decompressing with `GZipStream` and reading line by line.

### 2. Card model

In `Models/Card.cs`:
- Add `ResourceId` (`string?`, `resource_id`), `Defense` (`string?`),
  `GameChanger` (`bool?`, `game_changer`), `ImageUpdatedAt` (`DateTime?`,
  `image_updated_at`, comment that it is present live but undocumented).
- Replace the three `preview.*` properties with a `Preview? Preview` property
  backed by a new `Models/CardPreview.cs` (`PreviewedAt DateOnly?`,
  `SourceUri Uri?`, `Source string?`). Verify with Delver of Secrets
  (`cards/named?exact=Delver of Secrets`) that an empty `source_uri` string
  deserializes without throwing; if Newtonsoft's Uri conversion rejects it,
  type `SourceUri` as `string?` instead.
- `SecurityStamp`: `string?`, drop `required`.
- `OracleId`: `Guid?`.
- `ImageUris`: `ImageUris?` defaulting to null. `PurchaseUris`: `PurchaseUris?`
  defaulting to null. Remove the `http://localhost` defaults on these two.
  Leave the other URI defaults alone unless trivial; they are always present.
- Consider `cmc` as `decimal?` instead of `float?` (docs say Decimal). Do the
  same on `CardFace`, `CardSymbol.ManaValue`, `ManaCost.ConvertManaCost`.
  This is breaking but cheap now; skip if you prefer to keep scope tight.
- `Models/CardPrices.cs`: add `EurEtched` (`eur_etched`).
- `Models/FormatLegalities.cs`: add `CompetitiveBrawl` (`competitivebrawl`)
  and `Tlr` (`tlr`). Also add
  `[JsonExtensionData] public IDictionary<string, JToken>? AdditionalFormats`
  so formats added later are retained instead of dropped.
- `Models/PurchaseUris.cs`: add explicit `[JsonProperty]` attributes
  (`tcgplayer`, `cardmarket`, `cardhoarder`); it currently relies on
  case-insensitive matching.

### 3. Card face and symbol models

- `Models/CardFace.cs`: add `ArtistId` (`Guid?`, `artist_id`) and `Defense`
  (`string?`). Make `Loyalty` `string?`. Make `ImageUris` `ImageUris?` with
  null default (faces on single-faced cards have none).
- `Models/CardSymbol.cs`: add `Hybrid` and `Phyrexian` (`bool`).

### 4. Enums

- `SortingOrders`: add `TixPrice = "tix"`, `EurPrice = "eur"`.
- `CatalogTypes`: add `Supertypes = "supertypes"`, `CardTypes = "card-types"`,
  `BattleTypes = "battle-types"`, `FlavorWords = "flavor-words"`.
  `CatalogClientTests.FlexCatalogs` iterates every enum value against the live
  API, so it verifies these automatically.

### 5. Converters and list type

- Delete `Converters/CardFaceConverter.cs`.
- `RequestResponse/Response/ScryfallList.cs`: replace the System.Text.Json
  attribute on `HostedType` with Newtonsoft's `[JsonIgnore]`, or simply remove
  the field (it is only used by tests to assert `typeof(T)`, which is
  pointless). Removing is preferred; update the three rulings tests that
  reference it.
- `Converters/IdentifierConverter.WriteJson`: implement it by writing a start
  array, calling `serializer.Serialize(writer, identifier)` for each item, and
  writing an end array. Add a small round-trip check in the collection test.

### 6. New endpoints

Add `Clients/ApiClients/MigrationsClient.cs`:
- `Task<ScryfallList<Migration>> ListMigrationsAsync(int page = 1)` → `GET /migrations?page=N`
- `Task<Migration> GetMigrationAsync(Guid id)` → `GET /migrations/{id}`
- `Models/Migration.cs` fields from the docs: `id` (Guid), `uri` (Uri),
  `performed_at` (DateOnly), `migration_strategy` (string: `merge` or
  `delete`), `old_scryfall_id` (Guid), `new_scryfall_id` (Guid?), `note`
  (string?), `metadata` (`JObject?`).
- Expose as `MigrationsClient Migrations { get; }` on `IScryfallApiClient`
  and `ScryfallApiClient`.

Add manifest support to `CardsClient`:
- `Task<ScryfallList<ManifestEntry>> ManifestAsync(string? lang = null, ManifestOrder order = ManifestOrder.Released, int page = 1)`
  → `GET /cards/manifest`. `ManifestOrder` enum: `released`, `imageupdated`.
- The docs do not list the entry fields. Fetch
  `https://api.scryfall.com/cards/manifest?lang=en&page=1` exactly once
  (15,000 entries, 10 requests/minute limit), save the first entry, and model
  its fields. Expect at minimum an `id` and timestamps.
- Rate limit: if Plan 1 has merged, pass `RateLimitCategory.Manifest`.
  Otherwise leave a `// TODO(plan1): manifest is limited to 10/minute` comment
  and mark the live test `[Explicit]` so it does not run by default.

Tags have no REST endpoint; they are bulk files only. Add a
`Models/Tag.cs` and `Models/Tagging.cs` per the tags doc page so consumers of
the `art_tags` and `oracle_tags` bulk files have types to deserialize into.
Fields: tag = `id, slug, label, uri, type, description?, parent_ids?,
child_ids?, aliases?, taggings`; tagging = `illustration_id?, oracle_id?,
weight, annotation?`.

### 7. Keep the test project compiling

`Tests.Live/TestData/TestCards.cs`, `TestSets.cs`, `TestSymbologies.cs` use
object initializers for the models. Update them for every property you rename
or remove (for example `SecurityStamp` losing `required`, `ImageUris` becoming
nullable). Do not try to fix the 15 pre-existing equivalence failures; Plan 3
rewrites those tests.

## Verification

- Build succeeds.
- New `BulkDataClientTests` pass.
- `CatalogClientTests.FlexCatalogs` passes (covers the four new catalogs).
- Live: Delver of Secrets deserializes with `ImageUris == null`,
  `CardFaces.Length == 2`, each face having non-null `ImageUris`, and
  `Preview.PreviewedAt == 2025-01-07`.
- Live: Black Lotus (lea/232) deserializes with `SecurityStamp == null`.
- Live: a reversible card from `q=is:reversible unique:prints` deserializes
  with `OracleId == null` and each face having an `OracleId`.
- Live: `ListMigrationsAsync()` returns a list with `Data.Length > 0`.
- Add each of the above as tests.

## Out of scope

Error handling, throttling, query encoding (Plan 1). Version bump, README
breaking-change notes, CI, Splat (Plan 3).
