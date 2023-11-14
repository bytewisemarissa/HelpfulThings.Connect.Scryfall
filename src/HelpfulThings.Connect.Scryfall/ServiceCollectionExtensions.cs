using HelpfulThings.Connect.Scryfall.Clients;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddScryfallApi(this IServiceCollection collection)
    {
        collection.AddScoped<IScryfallApiClient, ScryfallApiClient>();
        collection.AddScoped<IScryfallIoClient, ScryfallIoClient>();

        return collection;
    }
}