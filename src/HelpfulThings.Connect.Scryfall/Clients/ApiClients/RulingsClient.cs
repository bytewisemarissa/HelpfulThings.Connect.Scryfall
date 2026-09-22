using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class RulingsClient : BaseApiClient
{
    private const string CardsEndpoint = "cards";
    private const string RulingsEndpoint = "rulings";

    public Task<ScryfallList<Ruling>> GetMultiverseCardRulingsAsync(
        int multiverseId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/multiverse/{multiverseId}/{RulingsEndpoint}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<ScryfallList<Ruling>> GetMtgoCardRulingsAsync(
        int mtgoId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/mtgo/{mtgoId}/{RulingsEndpoint}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<ScryfallList<Ruling>> GetArenaCardRulingsAsync(
        int arenaId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/arena/{arenaId}/{RulingsEndpoint}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<ScryfallList<Ruling>> GetRulingsBySetAndCollectorIdAsync(
        string setCode, string collectorId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/{setCode}/{collectorId}/{RulingsEndpoint}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<ScryfallList<Ruling>> GetRulingsByScryfallIdAsync(
        Guid scryfallId, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<Ruling>>(async () =>
            await ApiClient.GetAsync($"{CardsEndpoint}/{scryfallId}/{RulingsEndpoint}", cancellationToken),
            cancellationToken: cancellationToken);
}
