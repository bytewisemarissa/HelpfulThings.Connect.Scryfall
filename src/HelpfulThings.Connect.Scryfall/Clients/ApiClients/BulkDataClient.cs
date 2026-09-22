using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class BulkDataClient : BaseApiClient
{
    private const string BulkDataEndpoint = "bulk-data";

    public Task<ScryfallList<BulkData>> GetBulkDataListingAsync() =>
        MakeDelayedRequestAsync<ScryfallList<BulkData>>(async () => await ApiClient.GetAsync($"{BulkDataEndpoint}"));

    public Task<BulkData> GetBulkDataListingByTypeAsync(BulkTypes type) =>
        MakeDelayedRequestAsync<BulkData>(async () => await ApiClient.GetAsync($"{BulkDataEndpoint}/{type.GetEnumValue()}"));
        
    public Task<BulkData> GetBulkDataListingByIdAsync(Guid id) =>
        MakeDelayedRequestAsync<BulkData>(async () => await ApiClient.GetAsync($"{BulkDataEndpoint}/{id}"));
}