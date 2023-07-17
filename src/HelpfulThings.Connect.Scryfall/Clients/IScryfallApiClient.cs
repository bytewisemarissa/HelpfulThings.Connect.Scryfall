using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients;

public interface IScryfallApiClient
{
    BulkDataClient BulkData { get; }
    CardsClient Cards { get; }
    CatalogClient Catalog { get; }
    RulingsClient Rulings { get; }
    SetsClient Sets { get; }
    SymbologyClient Symbology { get; }
    Task<ScryfallList<T>> GetNextPageOfListResponseAsync<T>(ScryfallList<T> scryfallList);
}