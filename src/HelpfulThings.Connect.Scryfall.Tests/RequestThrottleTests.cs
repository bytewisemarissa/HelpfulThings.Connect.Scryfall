using System.Diagnostics;
using System.Net;
using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Tests.TestSupport;

namespace HelpfulThings.Connect.Scryfall.Tests;

/// <summary>
/// Confirms the per-endpoint throttling in <see cref="RequestThrottle"/> without hitting the
/// network, by pointing the shared client at a stub handler that answers instantly.
/// </summary>
public class RequestThrottleTests
{
    private const string MinimalCardJson =
        """{"layout":"normal","border_color":"black","frame":"2015","rarity":"common","set_type":"expansion"}""";

    [TearDown]
    public void ResetHandler() => BaseApiClient.UseHandlerForTests(new HttpClientHandler());

    [Test]
    public async Task ConsecutiveDefaultCategoryRequests_AreAtLeastOneHundredMillisecondsApart()
    {
        BaseApiClient.UseHandlerForTests(new StubHttpMessageHandler(HttpStatusCode.OK, MinimalCardJson));
        var client = new CardsClient();

        var total = Stopwatch.StartNew();
        await client.CardByScryfallIdAsync(Guid.NewGuid());
        await client.CardByScryfallIdAsync(Guid.NewGuid());
        total.Stop();

        total.Elapsed.Should().BeGreaterThanOrEqualTo(TimeSpan.FromMilliseconds(100));
    }

    [Test]
    public async Task ConsecutiveCardSearchCategoryRequests_AreAtLeastFiveHundredMillisecondsApart()
    {
        BaseApiClient.UseHandlerForTests(new StubHttpMessageHandler(HttpStatusCode.OK, MinimalCardJson));
        var client = new CardsClient();

        var total = Stopwatch.StartNew();
        await client.NamedAsync("Black Lotus", null, null);
        await client.NamedAsync("Black Lotus", null, null);
        total.Stop();

        total.Elapsed.Should().BeGreaterThanOrEqualTo(TimeSpan.FromMilliseconds(500));
    }

    [Test]
    public async Task EveryRequest_ActuallyReachesTheHandler()
    {
        var handler = new StubHttpMessageHandler(HttpStatusCode.OK, MinimalCardJson);
        BaseApiClient.UseHandlerForTests(handler);
        var client = new CardsClient();

        await client.CardByScryfallIdAsync(Guid.NewGuid());
        await client.CardByScryfallIdAsync(Guid.NewGuid());

        handler.RequestCount.Should().Be(2);
    }
}
