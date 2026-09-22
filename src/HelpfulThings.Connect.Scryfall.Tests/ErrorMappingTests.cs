using System.Net;
using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Tests.TestSupport;

namespace HelpfulThings.Connect.Scryfall.Tests;

public class ErrorMappingTests
{
    [TearDown]
    public void ResetHandler() => BaseApiClient.UseHandlerForTests(new HttpClientHandler());

    [Test]
    public async Task NotFoundResponse_MapsToScryfallApiExceptionWithErrorCode()
    {
        var errorBody = await File.ReadAllTextAsync(
            Path.Combine(AppContext.BaseDirectory, "Fixtures", "error-not-found.json"));
        BaseApiClient.UseHandlerForTests(new StubHttpMessageHandler(HttpStatusCode.NotFound, errorBody));
        var client = new CardsClient();

        var act = () => client.NamedAsync("Definitely Not A Card", null, null);

        var exception = await act.Should().ThrowAsync<ScryfallApiException>();
        exception.Which.StatusCode.Should().Be(HttpStatusCode.NotFound);
        exception.Which.Error.Should().NotBeNull();
        exception.Which.Error!.Code.Should().Be("not_found");
        exception.Which.Error!.Status.Should().Be(404);
    }

    [Test]
    public async Task TooManyRequestsResponse_MapsToScryfallRateLimitException()
    {
        BaseApiClient.UseHandlerForTests(new StubHttpMessageHandler(HttpStatusCode.TooManyRequests, "{}"));
        var client = new CardsClient();

        var act = () => client.NamedAsync("Black Lotus", null, null);

        var exception = await act.Should().ThrowAsync<ScryfallRateLimitException>();
        exception.Which.StatusCode.Should().Be(HttpStatusCode.TooManyRequests);
    }
}
