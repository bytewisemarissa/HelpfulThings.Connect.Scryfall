using HelpfulThings.Connect.Scryfall.Clients;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddScryfallApi(this IServiceCollection collection)
    {
        collection.AddScoped<IScryfallApiClient, ScryfallApiClient>();
    }
}