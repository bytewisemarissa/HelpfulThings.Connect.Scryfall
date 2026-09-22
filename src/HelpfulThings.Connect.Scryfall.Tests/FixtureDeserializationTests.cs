using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Tests;

/// <summary>
/// Deserializes real, recorded Scryfall responses so model regressions are caught offline,
/// without depending on the live API being reachable or stable at test time.
/// </summary>
public class FixtureDeserializationTests
{
    private static string ReadFixture(string fileName) =>
        File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", fileName));

    [Test]
    public void LightningBolt_SingleFaceCardWithAllParts_DeserializesWithoutError()
    {
        var card = JsonConvert.DeserializeObject<Card>(ReadFixture("card-lightning-bolt.json"));

        card.Should().NotBeNull();
        card!.Name.Should().Be("Lightning Bolt");
        card.CardFaces.Should().BeNull();
        card.ImageUris.Should().NotBeNull();
        card.RelatedCards.Should().HaveCount(4);
        card.SecurityStamp.Should().BeNull();
    }

    [Test]
    public void DelverOfSecrets_TransformCard_DeserializesWithoutErrorAndHasAPreview()
    {
        var card = JsonConvert.DeserializeObject<Card>(ReadFixture("card-delver-of-secrets.json"));

        card.Should().NotBeNull();
        card!.Layout.Should().Be("transform");
        card.ImageUris.Should().BeNull();
        card.CardFaces.Should().NotBeNull();
        card.CardFaces!.Should().HaveCount(2);
        card.CardFaces.Should().OnlyContain(face => face.ImageUris != null);
        card.Preview.Should().NotBeNull();
        card.Preview!.Source.Should().Be("Wizards of the Coast");
        card.Preview.PreviewedAt.Should().Be(new DateOnly(2025, 1, 7));
    }

    [Test]
    public void ReversibleCard_DeserializesWithoutErrorAndHasNoTopLevelOracleId()
    {
        var card = JsonConvert.DeserializeObject<Card>(ReadFixture("card-reversible.json"));

        card.Should().NotBeNull();
        card!.Layout.Should().Be("reversible_card");
        card.OracleId.Should().BeNull();
        card.CardFaces.Should().NotBeNull();
        card.CardFaces.Should().OnlyContain(face => face.OracleId != null);
    }

    [Test]
    public void ModernHorizons3_Set_DeserializesWithoutError()
    {
        var set = JsonConvert.DeserializeObject<Set>(ReadFixture("set-mh3.json"));

        set.Should().NotBeNull();
        set!.Code.Should().Be("mh3");
        set.Name.Should().Be("Modern Horizons 3");
    }

    [Test]
    public void BulkDataListing_DeserializesWithoutErrorAndEveryEntryHasADownloadUriAndSize()
    {
        var listing = JsonConvert.DeserializeObject<ScryfallList<BulkData>>(ReadFixture("bulk-data-list.json"));

        listing.Should().NotBeNull();
        listing!.Data.Should().NotBeEmpty();
        listing.Data.Should().OnlyContain(b => b.CompressedSize > 0);
        listing.Data.Should().OnlyContain(b => b.JsonlDownloadUri.Host != "localhost");
        listing.Data.Select(b => b.Type).Should().Contain(BulkTypes.OracleCards);
    }

    [Test]
    public void Symbology_DeserializesWithoutError()
    {
        var symbology = JsonConvert.DeserializeObject<ScryfallList<CardSymbol>>(ReadFixture("symbology.json"));

        symbology.Should().NotBeNull();
        symbology!.Data.Should().NotBeEmpty();
        symbology.Data.Should().Contain(s => s.Symbol == "{T}");
    }

    [Test]
    public void NotFoundError_DeserializesWithoutError()
    {
        var error = JsonConvert.DeserializeObject<ScryfallError>(ReadFixture("error-not-found.json"));

        error.Should().NotBeNull();
        error!.Code.Should().Be("not_found");
        error.Status.Should().Be(404);
    }

    [Test]
    public void CollectionResponseWithNotFound_DeserializesWithoutError()
    {
        var response =
            JsonConvert.DeserializeObject<CollectionResponse>(ReadFixture("collection-response-with-not-found.json"));

        response.Should().NotBeNull();
        response!.Data.Should().HaveCount(1);
        response.NotFound.Should().HaveCount(2);
    }

    [Test]
    public void MigrationsListing_DeserializesWithoutError()
    {
        var listing =
            JsonConvert.DeserializeObject<ScryfallList<Migration>>(ReadFixture("migrations-list.json"));

        listing.Should().NotBeNull();
        listing!.Data.Should().NotBeEmpty();
        listing.Data.Should().OnlyContain(m => m.OldScryfallId != Guid.Empty);
    }

    [Test]
    public void FormatLegalities_UnknownFutureFormat_IsRetainedInExtensionDataInsteadOfBeingDropped()
    {
        const string json = """
            {
              "standard": "legal",
              "modern": "legal",
              "some_future_format_not_yet_modeled": "banned"
            }
            """;

        var legalities = JsonConvert.DeserializeObject<FormatLegalities>(json);

        legalities.Should().NotBeNull();
        legalities!.Standard.Should().Be(Legalities.Legal);
        legalities.AdditionalFormats.Should().NotBeNull();
        legalities.AdditionalFormats!.Should().ContainKey("some_future_format_not_yet_modeled");
        legalities.AdditionalFormats["some_future_format_not_yet_modeled"]!.ToString().Should().Be("banned");
    }
}
