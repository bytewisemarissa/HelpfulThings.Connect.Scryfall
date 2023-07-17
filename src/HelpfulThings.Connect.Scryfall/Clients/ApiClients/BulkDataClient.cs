using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class BulkDataClient : BaseApiClient
{
    private const string BulkDataEndpoint = "bulk-data";
    
    public Task<IEnumerable<BulkData>> GetBulkDataListingAsync() =>
        MakeDelayedRequestAsync<IEnumerable<BulkData>>(async () => await ApiClient.GetAsync($"{BulkDataEndpoint}"));

    public Task<BulkData> GetBulkDataListingByTypeAsync(BulkTypes type) =>
        MakeDelayedRequestAsync<BulkData>(async () => await ApiClient.GetAsync($"{BulkDataEndpoint}/{type.GetEnumValue()}"));
        
    public Task<BulkData> GetBulkDataListingByIdAsync(Guid id) =>
        MakeDelayedRequestAsync<BulkData>(async () => await ApiClient.GetAsync($"{BulkDataEndpoint}/{id}"));
}