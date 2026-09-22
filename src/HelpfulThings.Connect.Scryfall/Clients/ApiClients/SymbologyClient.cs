using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;
using Microsoft.AspNetCore.WebUtilities;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class SymbologyClient : BaseApiClient
{
    private const string SymbologyEndpoint = "symbology";

    public Task<ScryfallList<CardSymbol>> GetSymbologyAsync(CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ScryfallList<CardSymbol>>(async () =>
            await ApiClient.GetAsync($"{SymbologyEndpoint}", cancellationToken),
            cancellationToken: cancellationToken);

    public Task<ManaCost> ParseManaCostAsync(string manaCost, CancellationToken cancellationToken = default) =>
        MakeDelayedRequestAsync<ManaCost>(async () =>
        {
            var queryParams = new Dictionary<string, string?>
            {
                ["cost"] = manaCost
            };

            return await ApiClient.GetAsync(
                QueryHelpers.AddQueryString($"{SymbologyEndpoint}/parse-mana", queryParams), cancellationToken);
        }, cancellationToken: cancellationToken);
}
