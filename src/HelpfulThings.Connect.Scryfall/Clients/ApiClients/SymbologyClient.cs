using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;
using Microsoft.AspNetCore.WebUtilities;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class SymbologyClient : BaseApiClient
{
    private const string SymbologyEndpoint = "symbology";

    public Task<ScryfallList<CardSymbol>> GetSymbologyAsync() =>
        MakeDelayedRequestAsync<ScryfallList<CardSymbol>>(async () => await ApiClient.GetAsync($"{SymbologyEndpoint}"));

    public Task<ManaCost> ParseManaCostAsync(string manaCost) =>
        MakeDelayedRequestAsync<ManaCost>(async () =>
        {
            var queryParams = new Dictionary<string, string>
            {
                ["cost"] = manaCost
            };

            return await ApiClient.GetAsync(QueryHelpers.AddQueryString($"{SymbologyEndpoint}/parse-mana",
                queryParams));
        });
}