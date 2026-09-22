using System.Diagnostics;
using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

namespace HelpfulThings.Connect.Scryfall.Tests.Live;

public class DelayedRequestTest
{
    private readonly CardsClient _cardsClient = new();

    [Test]
    public async Task ConsecutiveSearchRequestsAreAtLeastFiveHundredMillisecondsApart()
    {
        var total = Stopwatch.StartNew();
        await _cardsClient.SearchAsync(TestCards.BlackLotus1StEd.Name!);
        await _cardsClient.SearchAsync(TestCards.BlackLotus1StEd.Name!);
        total.Stop();

        total.Elapsed.Should().BeGreaterThanOrEqualTo(TimeSpan.FromMilliseconds(500));
    }

    [Test]
    public async Task ConsecutiveScryfallIdRequestsAreAtLeastOneHundredMillisecondsApart()
    {
        var total = Stopwatch.StartNew();
        await _cardsClient.CardByScryfallIdAsync(TestCards.BlackLotus1StEd.ScryfallId);
        await _cardsClient.CardByScryfallIdAsync(TestCards.BlackLotus1StEd.ScryfallId);
        total.Stop();

        total.Elapsed.Should().BeGreaterThanOrEqualTo(TimeSpan.FromMilliseconds(100));
    }
}
