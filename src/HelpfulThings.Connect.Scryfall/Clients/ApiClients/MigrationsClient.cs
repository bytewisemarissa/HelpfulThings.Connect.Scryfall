using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class MigrationsClient : BaseApiClient
{
    private const string MigrationsEndpoint = "migrations";

    public Task<ScryfallList<Migration>> ListMigrationsAsync(int page = 1) =>
        MakeDelayedRequestAsync<ScryfallList<Migration>>(async () =>
            await ApiClient.GetAsync($"{MigrationsEndpoint}?page={page}"));

    public Task<Migration> GetMigrationAsync(Guid id) =>
        MakeDelayedRequestAsync<Migration>(async () =>
            await ApiClient.GetAsync($"{MigrationsEndpoint}/{id}"));
}
