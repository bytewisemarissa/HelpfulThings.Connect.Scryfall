using System.Net.Http.Json;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients;

public class ScryfallApiClient : BaseApiClient, IScryfallApiClient
{
    public BulkDataClient BulkData { get; }
    public CardsClient Cards { get; }
    public CatalogClient Catalog { get; }
    public RulingsClient Rulings { get; }
    public SetsClient Sets { get; }
    public SymbologyClient Symbology { get; }

    public ScryfallApiClient()
    {
        BulkData = new BulkDataClient();
        Cards = new CardsClient();
        Catalog = new CatalogClient();
        Rulings = new RulingsClient();
        Sets = new SetsClient();
        Symbology = new SymbologyClient();
    }

    public Task<ScryfallList<T>> GetNextPageOfListResponseAsync<T>(ScryfallList<T> scryfallList) =>
        MakeDelayedRequestAsync<ScryfallList<T>>(() =>
        {
            if (!scryfallList.HasMore)
            {
                throw new ArgumentException("The provided ScryfallList response does not have more items.");
            }
            
            if (scryfallList.NextPage == null)
            {
                throw new NullReferenceException("The provided ScryfallList did not have a next page URI.");
            }
            
            return ApiClient.GetAsync(scryfallList.NextPage.PathAndQuery);
        });
}

