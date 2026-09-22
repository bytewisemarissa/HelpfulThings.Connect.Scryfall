using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class SetsClient : BaseApiClient
{
    private const string SetsEndpoint = "sets";

    public Task<ScryfallList<Set>> ListSets(CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<Set>>(async () =>
            await ApiClient.GetAsync($"{SetsEndpoint}", cancellationToken), cancellationToken: cancellationToken);

    public Task<Set> GetSetByCode(string setCode, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Set>(async () =>
            await ApiClient.GetAsync($"{SetsEndpoint}/{setCode}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<Set> GetSetByTcgPlayerId(int? tcgPlayerId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Set>(async () =>
            await ApiClient.GetAsync($"{SetsEndpoint}/tcgplayer/{tcgPlayerId}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<Set> GetSetByScryfallId(Guid scryfallId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<Set>(async () =>
            await ApiClient.GetAsync($"{SetsEndpoint}/{scryfallId}", cancellationToken),
            cancellationToken: cancellationToken);
}
