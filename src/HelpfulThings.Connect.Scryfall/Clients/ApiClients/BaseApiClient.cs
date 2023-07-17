using System.Net.Http.Json;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

public class BaseApiClient
{
    protected static readonly HttpClient ApiClient;
    private static readonly Semaphore Semaphore = new(1, 1);
    
    static BaseApiClient()
    {
        ApiClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api.scryfall.com")
        };
    }
    
    protected async Task<T> MakeDelayedRequestAsync<T>(Func<Task<HttpResponseMessage>> requestAction)
    {
        try
        {
            Semaphore.WaitOne();
            HttpResponseMessage response = await requestAction.Invoke();

            response.EnsureSuccessStatusCode();

            var resultJson = await response.Content.ReadAsStringAsync() ??
                       throw new InvalidOperationException("Api result could not be parsed.");

            var result = JsonConvert.DeserializeObject<T>(resultJson);
            
            FireRelease();

            if (result is null)
            {
                throw new NullReferenceException("Failed to parse json model.");
            }
            
            return result;
        }
        catch (Exception ex)
        {
            throw new ScryfallException(
                "There was a problem connecting to the Scryfall API. See inner exception for details.", ex);
        }
        finally
        {
            FireRelease();
        }
    }

    protected async Task<Stream> MakeDelayedRequestImageAsync(Func<Task<HttpResponseMessage>> requestAction)
    {
        try
        {
            Semaphore.WaitOne();
            
            HttpResponseMessage response = await requestAction.Invoke();

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStreamAsync();

            return result;
        }
        catch (Exception ex)
        {
            throw new ScryfallException(
                "There was a problem connecting to the Scryfall API. See inner exception for details.", ex);
        }
        finally
        {
            FireRelease();
        }
    }
    
    protected void FireRelease()
    {
#pragma warning disable CS4014
        Task.Run(async () =>
        {
            await Task.Delay(100);
            Semaphore.Release(1);
        });
#pragma warning restore CS4014
    }
}