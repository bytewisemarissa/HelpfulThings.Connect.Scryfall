using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class CatalogClient : BaseApiClient
{
    private const string CatalogEndpoint = "catalog";

    public Task<ScryfallCatalog> GetCatalogByTypeAsync(
        CatalogTypes type, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallCatalog>(async () =>
            await ApiClient.GetAsync($"{CatalogEndpoint}/{type.GetEnumValue()}", cancellationToken),
            cancellationToken: cancellationToken);
}
