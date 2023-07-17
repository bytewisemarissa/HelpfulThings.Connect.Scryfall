using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class SetsClient : BaseApiClient
{
    private const string SetsEndpoint = "sets";

    public Task<ScryfallList<Set>> ListSets() =>
        MakeDelayedRequestAsync<ScryfallList<Set>>(async () =>
            await ApiClient.GetAsync($"{SetsEndpoint}"));

    public Task<Set> GetSetByCode(string setCode) =>
        MakeDelayedRequestAsync<Set>(async () =>
            await ApiClient.GetAsync($"{SetsEndpoint}/{setCode}"));
    
    public Task<Set> GetSetByTcgPlayerId(int? tcgPlayerId) =>
        MakeDelayedRequestAsync<Set>(async () =>
            await ApiClient.GetAsync($"{SetsEndpoint}/tcgplayer/{tcgPlayerId}"));
    
    public Task<Set> GetSetByScryfallId(Guid scryfallId) =>
        MakeDelayedRequestAsync<Set>(async () =>
            await ApiClient.GetAsync($"{SetsEndpoint}/{scryfallId}"));
}