using System.Diagnostics;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

namespace HelpfulThings.Connect.Scryfall.Tests.Live;

public class DelayedRequestTest
{
    private readonly CardsClient _cardsClient = new();

    [Test]
    public async Task DelayRequestTest()
    {
        var requestOne = new Stopwatch();
        var requestTwo = new Stopwatch();
        var total = new Stopwatch();
        
        total.Start(); requestOne.Start();
        await _cardsClient.CardByScryfallIdAsync(TestCards.BlackLotus1StEd.ScryfallId);
        requestOne.Stop(); requestTwo.Start();
        await _cardsClient.CardByScryfallIdAsync(TestCards.BlackLotus1StEd.ScryfallId);
        requestTwo.Stop(); total.Stop();
    }
}