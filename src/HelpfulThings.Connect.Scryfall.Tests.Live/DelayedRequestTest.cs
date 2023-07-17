using System.Diagnostics;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

namespace HelpfulThings.Connect.Scryfall.Tests.Live;

public class DelayedRequestTest
{
    public CardsClient _CardsClient;

    public DelayedRequestTest()
    {
        _CardsClient = new CardsClient();
    }

    [Test]
    public async Task DelayRequestTest()
    {
        Stopwatch requestOne = new Stopwatch();
        Stopwatch requestTwo = new Stopwatch();
        Stopwatch total = new Stopwatch();
        
        total.Start(); requestOne.Start();
        await _CardsClient.CardByScryfallIdAsync(TestCards.BlackLotus1StEd.ScryfallId);
        requestOne.Stop(); requestTwo.Start();
        await _CardsClient.CardByScryfallIdAsync(TestCards.BlackLotus1StEd.ScryfallId);
        requestTwo.Stop(); total.Stop();

        var deadTime = total.Elapsed - (requestOne.Elapsed + requestTwo.Elapsed);
    }
}