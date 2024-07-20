using System.Text;
using System.Web;
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
        int page = 1) =>
        MakeDelayedRequestAsync<ScryfallList<Card>>(async () =>
        {
            var queryParams = new Dictionary<string, string>()
            {

                ["q"] = HttpUtility.HtmlEncode(searchQuery),
                ["unique"] = uniqueMode.GetEnumValue(),
                ["order"] = sortingOrder.GetEnumValue(),
                ["dir"] = sortingDirection.GetEnumValue(),
                ["include_extras"] = includeExtras.ToString(),
                ["include_multilingual"] = includeMultilingual.ToString(),
                ["include_variations"] = includeVariations.ToString(),
                ["page"] = page.ToString()
            };

            return await ApiClient.GetAsync(QueryHelpers.AddQueryString($"{CardsEndpoint}/search", queryParams));
        });

    public Task<Card> NamedAsync(string? exact, string? fuzzy, string? set) =>
        MakeDelayedRequestAsync<Card>(async () =>
        {
            var queryParams = BuildNamedQueryParamsBase(exact, fuzzy, set);

            return await ApiClient.GetAsync(QueryHelpers.AddQueryString($"{CardsEndpoint}/named", queryParams));
        });

    public Task<Stream> NamedImageAsync(
        string? exact,
        string? fuzzy,
        string? set,
        CardFaces cardFace,
        ImageVersions imageVersion) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = BuildNamedQueryParamsBase(exact, fuzzy, set);
            queryParams["format"] = "image";
            queryParams["face"] = cardFace.GetEnumValue();
            queryParams["version"] = imageVersion.GetEnumValue();

            return await ApiClient.GetAsync(QueryHelpers.AddQueryString($"{CardsEndpoint}/named", queryParams));
        });

    private Dictionary<string, string> BuildNamedQueryParamsBase(
        string? exact,
        string? fuzzy,
        string? set
        )
    {
        var queryParams = new Dictionary<string, string>();

        if (exact != null)
        {
            queryParams["exact"] = exact;
        }
        else
        {
            if (fuzzy != null) queryParams["fuzzy"] = fuzzy;
            else
            {
                throw new NullReferenceException("Fuzzy should not be null here.");
            }
        }

        if (set != null)
        {
            queryParams["set"] = set;
        }

        return queryParams;
    }

    public Task<ScryfallCatalog> AutoCompleteAsync(string searchQuery, bool includeExtras = false) =>
        MakeDelayedRequestAsync<ScryfallCatalog>(async () =>
        {
            var queryParams = new Dictionary<string, string>()
            {
                ["q"] = HttpUtility.HtmlEncode(searchQuery),
                ["include_extras"] = includeExtras.ToString()
            };

            return await ApiClient.GetAsync(QueryHelpers.AddQueryString($"{CardsEndpoint}/autocomplete",
                queryParams));
        });

    public Task<Card> RandomAsync(string? searchQuery) =>
        MakeDelayedRequestAsync<Card>(async () =>
        {
            var queryParams = new Dictionary<string, string>();

            if (searchQuery != null)
            {
                queryParams["q"] = HttpUtility.HtmlEncode(searchQuery);
            }

            return await ApiClient.GetAsync(QueryHelpers.AddQueryString($"{CardsEndpoint}/random",
                queryParams));
        });

    public Task<Stream> RandomImageAsync(string? searchQuery, CardFaces? cardFace, ImageVersions? imageVersion) => 
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string>();

            if (searchQuery != null)
            {
                queryParams["q"] = HttpUtility.HtmlEncode(searchQuery);
            }

            if (cardFace != null)
            {
                queryParams["face"] = cardFace.GetEnumValue();
            }

            if (imageVersion != null)
            {
                queryParams["version"] = imageVersion.GetEnumValue();
            }
            
            return await ApiClient.GetAsync(QueryHelpers.AddQueryString($"{CardsEndpoint}/random",
                queryParams));
        });

    public Task<CollectionResponse> CollectionAsync(CollectionRequest request) =>
        MakeDelayedRequestAsync<CollectionResponse>(async () =>
        {
            var requestJson = JsonConvert.SerializeObject(request);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            return await ApiClient.PostAsync($"{CardsEndpoint}/collection", requestContent);
        });

    public Task<Card> CardBySetCollectorNumberAsync(string setCode, string collectorNumber, string? language = null) =>
        MakeDelayedRequestAsync<Card>(async () => 
            await ApiClient.GetAsync($"{CardsEndpoint}/{setCode}/{collectorNumber}/{language ?? ""}"));

    public Task<Stream> CardBySetCollectorNumberImageAsync(string setCode, string collectorNumber, string? language = null,
        CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/{setCode}/{collectorNumber}/{language ?? ""}",
                queryParams));
        });

    public Task<Card> CardByMultiverseIdAsync(int multiverseId) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/multiverse/{multiverseId}"));

    public Task<Stream> CardImageByMultiverseIdAsync(
        int multiverseId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/multiverse/{multiverseId}", queryParams));
        });
    
    public Task<Card> CardByMtgoIdAsync(int mtgo) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/mtgo/{mtgo}"));

    public Task<Stream> CardImageByMtgoIdAsync(
        int mtgo, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/mtgo/{mtgo}", queryParams));
        });
    
    public Task<Card> CardByArenaIdAsync(int arenaId) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/arena/{arenaId}"));

    public Task<Stream> CardImageByArenaIdAsync(
        int arenaId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/arena/{arenaId}", queryParams));
        });
    
    public Task<Card> CardByTcgPlayerIdAsync(int tcgPlayerId) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/tcgplayer/{tcgPlayerId}"));

    public Task<Stream> CardImageByTcgPlayerIdAsync(
        int tcgPlayerId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/tcgplayer/{tcgPlayerId}", queryParams));
        });
    
    public Task<Card> CardByCardMarketIdAsync(int cardMarketId) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/cardmarket/{cardMarketId}"));

    public Task<Stream> CardImageByCardMarketIdAsync(
        int cardMarketId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/cardmarket/{cardMarketId}", queryParams));
        });
    
    public Task<Card> CardByScryfallIdAsync(Guid scryfallId) =>
        MakeDelayedRequestAsync<Card>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/{scryfallId}"));

    public Task<Stream> CardImageByScryfallIdAsync(
        Guid scryfallId, CardFaces cardFace = CardFaces.Front, ImageVersions imageVersion = ImageVersions.Large) =>
        MakeDelayedRequestImageAsync(async () =>
        {
            var queryParams = new Dictionary<string, string>()
            {
                ["format"] = "image",
                ["face"] = cardFace.GetEnumValue(),
                ["version"] = imageVersion.GetEnumValue()
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{CardsEndpoint}/{scryfallId}", queryParams));
        });
}