using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class RulingsClient : BaseApiClient
{
    private const string CardsEndpoint = "cards";
    private const string RulingsEndpoint = "rulings";

    public Task<ScryfallList<Ruling>> GetMultiverseCardRulingsAsync(int multiverseId) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/multiverse/{multiverseId}/{RulingsEndpoint}"));
    
    public Task<ScryfallList<Ruling>> GetMtgoCardRulingsAsync(int mtgoId) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/mtgo/{mtgoId}/{RulingsEndpoint}"));
    
    public Task<ScryfallList<Ruling>> GetArenaCardRulingsAsync(int arenaId) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/arena/{arenaId}/{RulingsEndpoint}"));
    
    public Task<ScryfallList<Ruling>> GetRulingsBySetAndCollectorIdAsync(string setCode, string collectorId) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/{setCode}/{collectorId}/{RulingsEndpoint}"));
    
    public Task<ScryfallList<Ruling>> GetRulingsByScryfallIdAsync(Guid scryfallId) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/{scryfallId}/{RulingsEndpoint}"));
}
