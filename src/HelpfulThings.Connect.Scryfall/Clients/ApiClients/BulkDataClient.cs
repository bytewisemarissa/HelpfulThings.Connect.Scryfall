using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class BulkDataClient : BaseApiClient
{
    private const string BulkDataEndpoint = "bulk-data";

    public Task<IEnumerable<BulkData>> GetBulkDataListingAsync(CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<IEnumerable<BulkData>>(async () =>
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
