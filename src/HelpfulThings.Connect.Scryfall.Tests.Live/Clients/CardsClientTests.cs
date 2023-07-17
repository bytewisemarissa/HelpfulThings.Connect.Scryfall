using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Identifiers;
using HelpfulThings.Connect.Scryfall.RequestResponse.Request;
using HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.Clients;

public class CardsClientTests
{
    private CardsClient _clientUnderTest;

    
    [SetUp]
    public void Setup()
    {
        _clientUnderTest = new CardsClient();
    }

    [Test]
    public async Task Search()
    {
        var result = await _clientUnderTest.SearchAsync(
            TestCards.BlackLotus1StEd.Name!, 
            UniqueModes.Prints, 
            SortingOrders.Released,
            SortingDirection.Ascending);

        var firstSearchResult = result.Data.First();
        firstSearchResult.Should().BeEquivalentTo(TestCards.BlackLotus1StEd);
    }

    [Test]
    public async Task Named()
    {
        var result = await _clientUnderTest.NamedAsync(
            TestCards.BlackLotus1StEd.Name, 
            null, 
            TestCards.BlackLotus1StEd.SetCode);
        
        result.Should().BeEquivalentTo(TestCards.BlackLotus1StEd);
    }

    [Test]
    public async Task NamedImage()
    {
        var result = await _clientUnderTest.NamedImageAsync(
            TestCards.BlackLotus1StEd.Name, 
            null, 
            TestCards.BlackLotus1StEd.SetCode,
            CardFaces.Front,
            ImageVersions.Small);
        
        result.Length.Should().BeGreaterThan(0);
    }

    [Test]
    public async Task AutoComplete()
    {
        var result = await _clientUnderTest.AutoCompleteAsync("Black", true);

        result.Data.Count.Should().BeGreaterThan(0);
    }

    [Test]
    public async Task Collection()
    {
        var request = new CollectionRequest()
        {
            Identifiers = new List<Identifier>()
            {
                new CollectorNumberSetIdentifier(TestCards.BlackLotus1StEd.CollectorNumber, TestCards.BlackLotus1StEd.SetCode),
                new IllustrationIdentifier()
                {
                    IllustrationId = TestCards.BlackLotus1StEd.IllustrationId!.Value
                },
                new MtgoIdentifier()
                {
                    MtgoId = TestCards.BlackLotus1StEd.MtgoId!.Value
                },
                new MultiverseIdentifier()
                {
                    MultiverseId = TestCards.BlackLotus1StEd.MultiverseIds!.First()
                },
                new NameIdentifier()
                {
                    Name = TestCards.BlackLotus1StEd.Name!
                },
                new OracleIdentifier()
                {
                    OracleId = TestCards.BlackLotus1StEd.OracleId
                },
                new ScryfallIdentifier()
                {
                    ScryfallId = TestCards.BlackLotus1StEd.ScryfallId
                }
            }
        };

        var result = await _clientUnderTest.CollectionAsync(request);

        result.Data.Count.Should().Be(request.Identifiers.Count);
        foreach (var card in result.Data)
        {
            card.Name.Should().Be(TestCards.BlackLotus1StEd.Name);
        }
    }

    [Test]
    public async Task BySetCollectorNumber()
    {
        var result =
            await _clientUnderTest.CardBySetCollectorNumberAsync(
                TestCards.BlackLotus1StEd.SetCode, TestCards.BlackLotus1StEd.CollectorNumber);

        result.Should().BeEquivalentTo(TestCards.BlackLotus1StEd);
    }
    
    [Test]
    public async Task BySetCollectorNumberImage()
    {
        var result =
            await _clientUnderTest.CardBySetCollectorNumberImageAsync(
                TestCards.BlackLotus1StEd.SetCode, 
                TestCards.BlackLotus1StEd.CollectorNumber, 
                null,
                CardFaces.Front,
                ImageVersions.Small);

        result.Length.Should().BeGreaterThan(0);
    }
    
    [Test]
    public async Task ByMultiverseId()
    {
        var result =
            await _clientUnderTest.CardByMultiverseIdAsync(TestCards.BlackLotus1StEd.MultiverseIds!.First());

        result.Should().BeEquivalentTo(TestCards.BlackLotus1StEd);
    }
    
    [Test]
    public async Task ByMultiverseIdImage()
    {
        var result =
            await _clientUnderTest.CardImageByMultiverseIdAsync(TestCards.BlackLotus1StEd.MultiverseIds!.First(), 
                CardFaces.Front, 
                ImageVersions.Small);

        result.Length.Should().BeGreaterThan(0);
    }
    
    [Test]
    public async Task ByMtgoId()
    {
        var result =
            await _clientUnderTest.CardByMtgoIdAsync(TestCards.BlackLotus1StEd.MtgoId!.Value);

        result.Should().BeEquivalentTo(TestCards.BlackLotus1StEd);
    }
    
    [Test]
    public async Task ByMtgoIdImage()
    {
        var result =
            await _clientUnderTest.CardImageByMtgoIdAsync(
                TestCards.BlackLotus1StEd.MtgoId!.Value, 
                CardFaces.Front, 
                ImageVersions.Small);

        result.Length.Should().BeGreaterThan(0);
    }
    
    /*
    [Test]
    public async Task BySetArenaId()
    {
        var result =
            await _clientUnderTest.CardByArenaId(_expectedResult.ArenaId);

        result.Should().BeEquivalentTo(_expectedResult);
    }
    
    [Test]
    public async Task ByArenaIdImage()
    {
        var result =
            await _clientUnderTest.CardImageByArenaId(
                _expectedResult.ArenaId, 
                CardFaces.Front, 
                ImageVersions.Small);

        result.Length.Should().BeGreaterThan(0);
    }
    */
    
    [Test]
    public async Task ByTcgPlayerId()
    {
        var result =
            await _clientUnderTest.CardByTcgPlayerIdAsync(TestCards.BlackLotus1StEd.TcgPlayerId!.Value);

        result.Should().BeEquivalentTo(TestCards.BlackLotus1StEd);
    }
    
    [Test]
    public async Task ByTcgPlayerIdImage()
    {
        var result =
            await _clientUnderTest.CardImageByTcgPlayerIdAsync(
                TestCards.BlackLotus1StEd.TcgPlayerId!.Value, 
                CardFaces.Front, 
                ImageVersions.Small);

        result.Length.Should().BeGreaterThan(0);
    }
    
    [Test]
    public async Task ByCardMarketId()
    {
        var result =
            await _clientUnderTest.CardByCardMarketIdAsync(TestCards.BlackLotus1StEd.CardmarketId!.Value);

        result.Should().BeEquivalentTo(TestCards.BlackLotus1StEd);
    }
    
    [Test]
    public async Task ByCardMarketIdImage()
    {
        var result =
            await _clientUnderTest.CardImageByCardMarketIdAsync(
                TestCards.BlackLotus1StEd.CardmarketId!.Value, 
                CardFaces.Front, 
                ImageVersions.Small);

        result.Length.Should().BeGreaterThan(0);
    }
    
    [Test]
    public async Task ByScryfallIdBlackLotus1StEd()
    {
        var result =
            await _clientUnderTest.CardByScryfallIdAsync(TestCards.BlackLotus1StEd.ScryfallId);

        result.Should().BeEquivalentTo(TestCards.BlackLotus1StEd);
    }
    
    [Test]
    public async Task ByScryfallIdDereviEmpyrialTactician()
    {
        var result =
            await _clientUnderTest.CardByScryfallIdAsync(TestCards.DereviEmpyrialTactician.ScryfallId);

        result.Should().BeEquivalentTo(TestCards.DereviEmpyrialTactician);
    }
    
    [Test]
    public async Task ByScryfallIdImage()
    {
        var result =
            await _clientUnderTest.CardImageByScryfallIdAsync(
                TestCards.BlackLotus1StEd.ScryfallId, 
                CardFaces.Front, 
                ImageVersions.Small);

        result.Length.Should().BeGreaterThan(0);
    }
}