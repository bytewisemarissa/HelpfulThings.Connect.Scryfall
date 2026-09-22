using System.Net;
using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.Clients;

[Category("Live")]
public class ErrorHandlingTests
{
    private CardsClient _clientUnderTest;

    [SetUp]
    public void Setup()
    {
        _clientUnderTest = new CardsClient();
    }

    [Test]
    public async Task Search_WithQuotedPhrase_ReturnsResults()
    {
        var result = await _clientUnderTest.SearchAsync("o:\"draw a card\" t:instant");

        result.TotalCards.Should().BeGreaterThan(0);
    }

    [Test]
    public async Task Named_UnknownCard_ThrowsScryfallApiExceptionWithNotFound()
    {
        var act = () => _clientUnderTest.NamedAsync("Definitely Not A Card", null, null);

        var exception = await act.Should().ThrowAsync<ScryfallApiException>();
        exception.Which.StatusCode.Should().Be(HttpStatusCode.NotFound);
        exception.Which.Error.Should().NotBeNull();
        exception.Which.Error!.Code.Should().Be("not_found");
    }

    [Test]
    public async Task NamedImage_CardWithoutBackFace_ThrowsScryfallApiExceptionWithUnprocessableEntity()
    {
        var act = () => _clientUnderTest.NamedImageAsync(
            "Lightning Bolt", null, null, CardFaces.Back, ImageVersions.Small);

        var exception = await act.Should().ThrowAsync<ScryfallApiException>();
        exception.Which.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
    }

    [Test]
    public void Named_NoExactOrFuzzy_ThrowsArgumentExceptionSynchronously()
    {
        Action act = () => _clientUnderTest.NamedAsync(null, null, null);

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public async Task ByScryfallId_KnownCard_DoesNotThrow()
    {
        var result = await _clientUnderTest.CardByScryfallIdAsync(TestCards.BlackLotus1StEd.ScryfallId);

        result.Should().NotBeNull();
    }
}
