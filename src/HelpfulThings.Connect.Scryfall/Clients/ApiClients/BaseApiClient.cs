using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using HelpfulThings.Connect.Scryfall.Models;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class BaseApiClient
{
    protected static readonly HttpClient ApiClient;

    static BaseApiClient()
    {
        var handler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(15)
        };

        ApiClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://api.scryfall.com")
        };

        ApiClient
            .DefaultRequestHeaders
            .UserAgent
            .Add(new ProductInfoHeaderValue(
                "HelpfulThings-Connect-Scryfall",
                GetAssemblyVersion()
                )
            );

        ApiClient
            .DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public static void UpdateUserAgent(ProductInfoHeaderValue productInfoHeaderValue)
    {
        ApiClient.DefaultRequestHeaders.UserAgent.Clear();

        ApiClient
            .DefaultRequestHeaders
            .UserAgent
            .Add(productInfoHeaderValue);
    }

    private static string GetAssemblyVersion()
    {
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
               ?? assembly.GetName().Version?.ToString()
               ?? "0.0.0";
    }

    protected Task<T> MakeDelayedRequestAsync<T>(
        Func<Task<HttpResponseMessage>> requestAction,
        RateLimitCategory category = RateLimitCategory.Default,
        CancellationToken cancellationToken = default) =>
        RequestThrottle.ThrottleAsync(category, async () =>
        {
            var response = await InvokeAsync(requestAction);

            await EnsureSuccessAsync(response, cancellationToken);

            string resultJson;
            try
            {
                resultJson = await response.Content.ReadAsStringAsync(cancellationToken);
            }
            catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
            {
                throw new ScryfallException(
                    "There was a problem connecting to the Scryfall API. See inner exception for details.", ex);
            }

            T result;
            try
            {
                result = JsonConvert.DeserializeObject<T>(resultJson) ??
                         throw new NullReferenceException("Failed to parse json model.");
            }
            catch (JsonException ex)
            {
                throw new ScryfallException(
                    "There was a problem connecting to the Scryfall API. See inner exception for details.", ex);
            }

            return result;
        }, cancellationToken);

    protected Task<Stream> MakeDelayedRequestImageAsync(
        Func<Task<HttpResponseMessage>> requestAction,
        RateLimitCategory category = RateLimitCategory.Default,
        CancellationToken cancellationToken = default) =>
        RequestThrottle.ThrottleAsync(category, async () =>
        {
            var response = await InvokeAsync(requestAction);

            await EnsureSuccessAsync(response, cancellationToken);

            try
            {
                return await response.Content.ReadAsStreamAsync(cancellationToken);
            }
            catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
            {
                throw new ScryfallException(
                    "There was a problem connecting to the Scryfall API. See inner exception for details.", ex);
            }
        }, cancellationToken);

    private static async Task<HttpResponseMessage> InvokeAsync(Func<Task<HttpResponseMessage>> requestAction)
    {
        try
        {
            return await requestAction.Invoke();
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            throw new ScryfallException(
                "There was a problem connecting to the Scryfall API. See inner exception for details.", ex);
        }
    }

    private static async Task EnsureSuccessAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        ScryfallError? error;
        try
        {
            error = JsonConvert.DeserializeObject<ScryfallError>(body);
        }
        catch (JsonException)
        {
            error = null;
        }

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            throw new ScryfallRateLimitException(error, body, response.Headers.RetryAfter?.Delta);
        }

        throw new ScryfallApiException(response.StatusCode, error, body);
    }
}
