using System.Net;
using System.Text;

namespace HelpfulThings.Connect.Scryfall.Tests.TestSupport;

/// <summary>
/// Returns a fixed status code and body for every request, so client code can be exercised
/// without touching the network. <see cref="RequestCount"/> lets throttle tests confirm how
/// many requests actually went out.
/// </summary>
public class StubHttpMessageHandler(HttpStatusCode statusCode, string responseBody) : HttpMessageHandler
{
    public int RequestCount { get; private set; }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        RequestCount++;

        var response = new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(responseBody, Encoding.UTF8, "application/json")
        };

        return Task.FromResult(response);
    }
}
