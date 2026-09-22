using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Enums;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.Clients;

/// <summary>
/// Live checks for the drift documented in plan 02: fields that changed shape,
/// nullability, or disappeared entirely between the old model and today's API.
/// </summary>
[Category("Live")]
public class CardModelDriftTests
{
    private CardsClient _clientUnderTest;

    [SetUp]
    public void Setup()
    {
        _clientUnderTest = new CardsClient();
    }

    [Test]
    public async Task DelverOfSecrets_DoubleFacedCard_HasNoTopLevelImageUrisAndHasAPreview()
    {
        var result = await _clientUnderTest.NamedAsync("Delver of Secrets", null, null);

        result.ImageUris.Should().BeNull();
        result.CardFaces.Should().NotBeNull();
        result.CardFaces!.Length.Should().Be(2);
        result.CardFaces.Should().OnlyContain(face => face.ImageUris != null);
        result.Preview.Should().NotBeNull();
        result.Preview!.PreviewedAt.Should().Be(new DateOnly(2025, 1, 7));
    }

    [Test]
    public async Task BlackLotus_SecurityStampIsAbsentToday()
    {
        var result = await _clientUnderTest.CardBySetCollectorNumberAsync("lea", "232");

        result.SecurityStamp.Should().BeNull();
    }

    [Test]
    public async Task ReversibleCard_HasNoTopLevelOracleIdButEachFaceDoes()
    {
        var result = await _clientUnderTest.SearchAsync(
            "is:reversible unique:prints", UniqueModes.Prints, SortingOrders.Name);

        var reversibleCard = result.Data.First(card => card.Layout == "reversible_card");

        reversibleCard.OracleId.Should().BeNull();
        reversibleCard.CardFaces.Should().NotBeNull();
        reversibleCard.CardFaces.Should().OnlyContain(face => face.OracleId != null);
    }
}
