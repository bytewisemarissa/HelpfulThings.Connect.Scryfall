using HelpfulThings.Connect.Scryfall.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace HelpfulThings.Connect.Scryfall;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddScryfallApi(this IServiceCollection collection)
    {
        collection.AddSingleton<IScryfallApiClient, ScryfallApiClient>();
        collection.AddSingleton<IScryfallIoClient, ScryfallIoClient>();

        return collection;
    }
}