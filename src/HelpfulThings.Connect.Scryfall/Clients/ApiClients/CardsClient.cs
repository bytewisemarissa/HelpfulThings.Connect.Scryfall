using System.Text;
using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Request;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class CardsClient : BaseApiClient
{
    private const string CardsEndpoint = "cards";

    public Task<ScryfallList<Card>> SearchAsync(
        string searchQuery,
        UniqueModes uniqueMode = UniqueModes.Cards,
        SortingOrders sortingOrder = SortingOrders.Name,
        SortingDirection sortingDirection = SortingDirection.Auto,
        bool includeExtras = false,
        bool includeMultilingual = false,
        bool includeVariations = false,
        int page = 1,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<Card>>(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {

                ["q"] = searchQuery,
                ["unique"] = uniqueMode.GetEnumValue(),
                ["order"] = sortingOrder.GetEnumValue(),
                ["dir"] = sortingDirection.GetEnumValue(),
                ["include_extras"] = ToLowerString(includeExtras),
                ["include_multilingual"] = ToLowerString(includeMultilingual),
                ["include_variations"] = ToLowerString(includeVariations),
                ["page"] = page.ToString()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/search", queryParams), cancellationToken);
        }, RateLimitCategory.CardSearch, cancellationToken);

    public Task<Card> NamedAsync(string? exact, string? fuzzy, string? set, CancellationToken cancellationToken = default)
    {
        var queryParams = BuildNamedQueryParamsBase(exact, fuzzy, set);

        return MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/named", queryParams), cancellationToken),
            RateLimitCategory.CardSearch, cancellationToken);
    }

    public Task<Stream> NamedImageAsync(
        string? exact,
        string? fuzzy,
        string? set,
        CardFaces cardFace,
        ImageVersions imageVersion,
        CancellationToken cancellationToken = default)
    {
        var queryParams = BuildNamedQueryParamsBase(exact, fuzzy, set);
        queryParams["format"] = "image";
        queryParams["face"] = cardFace.GetEnumValue();
        queryParams["version"] = imageVersion.GetEnumValue();

        return MakeDelayedRequestImageAsync(async () =>
            await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/named", queryParams), cancellationToken),
            RateLimitCategory.CardSearch, cancellationToken);
    }

    private static Dictionary<string, string?> BuildNamedQueryParamsBase(
        string? exact,
        string? fuzzy,
        string? set
        )
    {
        var queryParams = new Dictionary<string, string?>();

        if (exact != null)
        {
            queryParams["exact"] = exact;
        }
        else if (fuzzy != null)
        {
            queryParams["fuzzy"] = fuzzy;
        }
        else
        {
            throw new ArgumentException("Either exact or fuzzy must be provided.");
        }

        if (set != null)
        {
            queryParams["set"] = set;
        }

        return queryParams;
    }

    public Task<ScryfallCatalog> AutoCompleteAsync(
        string searchQuery, bool includeExtras = false, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallCatalog>(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {
                ["q"] = searchQuery,
                ["include_extras"] = ToLowerString(includeExtras)
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/autocomplete", queryParams), cancellationToken);
        }, cancellationToken: cancellationToken);

    public Task<Card> RandomAsync(string? searchQuery, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Card>(async () =>
        {
            var queryParams = new Dictionary<string, string?>();

            if (searchQuery != null)
            {
                queryParams["q"] = searchQuery;
            }

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/random", queryParams), cancellationToken);
        }, RateLimitCategory.CardSearch, cancellationToken);

    public Task<Stream> RandomImageAsync(
        string? searchQuery, CardFaces? cardFace, ImageVersions? imageVersion,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string?>();

            if (searchQuery != null)
            {
                queryParams["q"] = searchQuery;
            }

            if (cardFace != null)
            {
                queryParams["face"] = cardFace.GetEnumValue();
            }

            if (imageVersion != null)
            {
                queryParams["version"] = imageVersion.GetEnumValue();
            }

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/random", queryParams), cancellationToken);
        }, RateLimitCategory.CardSearch, cancellationToken);

    public Task<CollectionResponse> CollectionAsync(
        CollectionRequest request, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<CollectionResponse>(async () =>
        {
            var requestJson = JsonConvert.SerializeObject(request);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            return await ApiClient.PostAsync($"{CardsEndpoint}/collection", requestContent, cancellationToken);
        }, RateLimitCategory.CardSearch, cancellationToken);

    public Task<Card> CardBySetCollectorNumberAsync(
        string setCode, string collectorNumber, string? language = null,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync(
                BuildSetCollectorNumberPath(setCode, collectorNumber, language), cancellationToken),
            cancellationToken: cancellationToken);

    public Task<Stream> CardBySetCollectorNumberImageAsync(
        string setCode, string collectorNumber, string? language = null,
        CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString(
                    BuildSetCollectorNumberPath(setCode, collectorNumber, language), queryParams),
                cancellationToken);
        }, cancellationToken: cancellationToken);

    private static string BuildSetCollectorNumberPath(string setCode, string collectorNumber, string? language) =>
        language is null
            ? $"{CardsEndpoint}/{setCode}/{collectorNumber}"
            : $"{CardsEndpoint}/{setCode}/{collectorNumber}/{language}";

    public Task<Card> CardByMultiverseIdAsync(int multiverseId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/multiverse/{multiverseId}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<Stream> CardImageByMultiverseIdAsync(
        int multiverseId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/multiverse/{multiverseId}", queryParams),
                cancellationToken);
        }, cancellationToken: cancellationToken);

    public Task<Card> CardByMtgoIdAsync(int mtgo, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/mtgo/{mtgo}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<Stream> CardImageByMtgoIdAsync(
        int mtgo, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/mtgo/{mtgo}", queryParams), cancellationToken);
        }, cancellationToken: cancellationToken);

    public Task<Card> CardByArenaIdAsync(int arenaId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/arena/{arenaId}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<Stream> CardImageByArenaIdAsync(
        int arenaId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/arena/{arenaId}", queryParams), cancellationToken);
        }, cancellationToken: cancellationToken);

    public Task<Card> CardByTcgPlayerIdAsync(int tcgPlayerId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/tcgplayer/{tcgPlayerId}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<Stream> CardImageByTcgPlayerIdAsync(
        int tcgPlayerId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/tcgplayer/{tcgPlayerId}", queryParams),
                cancellationToken);
        }, cancellationToken: cancellationToken);

    public Task<Card> CardByCardMarketIdAsync(int cardMarketId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/cardmarket/{cardMarketId}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<Stream> CardImageByCardMarketIdAsync(
        int cardMarketId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/cardmarket/{cardMarketId}", queryParams),
                cancellationToken);
        }, cancellationToken: cancellationToken);

    public Task<ScryfallList<ManifestEntry>> ManifestAsync(
        string? lang = null, ManifestOrder order = ManifestOrder.Released, int page = 1,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<ManifestEntry>>(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {
                ["order"] = order.GetEnumValue(),
                ["page"] = page.ToString()
            };

            if (lang != null)
            {
                queryParams["lang"] = lang;
            }

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/manifest", queryParams), cancellationToken);
        }, RateLimitCategory.Manifest, cancellationToken);

    public Task<Card> CardByScryfallIdAsync(Guid scryfallId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/{scryfallId}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<Stream> CardImageByScryfallIdAsync(
        Guid scryfallId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large,
        CancellationToken cancellationToken = default) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string?>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/{scryfallId}", queryParams), cancellationToken);
        }, cancellationToken: cancellationToken);

    private static string ToLowerString(bool value) => value ? "true" : "false";
}
