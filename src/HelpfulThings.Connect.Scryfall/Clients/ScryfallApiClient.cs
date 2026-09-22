using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients;

public class ScryfallApiClient : BaseApiClient, IScryfallApiClient
{
    public BulkDataClient BulkData { get; } = new();
    public CardsClient Cards { get; } = new();
    public CatalogClient Catalog { get; } = new();
    public MigrationsClient Migrations { get; } = new();
    public RulingsClient Rulings { get; } = new();
    public SetsClient Sets { get; } = new();
    public SymbologyClient Symbology { get; } = new();

    public Task<ScryfallList<T>> GetNextPageOfListResponseAsync<T>(
        ScryfallList<T> scryfallList, CancellationToken cancellationToken = default)
    {
        if (!scryfallList.HasMore)
        {
            throw new ArgumentException("The provided ScryfallList response does not have more items.");
        }

        if (scryfallList.NextPage == null)
        {
            throw new ArgumentException("The provided ScryfallList did not have a next page URI.");
        }

        return MakeDelayedRequestAsync<ScryfallList<T>>(
            () => ApiClient.GetAsync(scryfallList.NextPage.PathAndQuery, cancellationToken),
            cancellationToken: cancellationToken);
    }
}

