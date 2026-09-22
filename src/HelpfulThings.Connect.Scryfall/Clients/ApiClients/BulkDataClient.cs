using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class BulkDataClient : BaseApiClient
{
    private const string BulkDataEndpoint = "bulk-data";

    public Task<ScryfallList<BulkData>> GetBulkDataListingAsync(CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<BulkData>>(async () =>
            await ApiClient.GetAsync($"{BulkDataEndpoint}", cancellationToken), cancellationToken: cancellationToken);

    public Task<BulkData> GetBulkDataListingByTypeAsync(
        BulkTypes type, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<BulkData>(async () =>
            await ApiClient.GetAsync($"{BulkDataEndpoint}/{type.GetEnumValue()}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<BulkData> GetBulkDataListingByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<BulkData>(async () =>
            await ApiClient.GetAsync($"{BulkDataEndpoint}/{id}", cancellationToken),
            cancellationToken: cancellationToken);
}
