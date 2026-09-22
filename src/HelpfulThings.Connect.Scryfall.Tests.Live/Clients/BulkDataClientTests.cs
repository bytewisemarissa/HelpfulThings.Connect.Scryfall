using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Enums;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.Clients;

[Category("Live")]
public class BulkDataClientTests
{
    private BulkDataClient _clientUnderTest;

    [SetUp]
    public void Setup()
    {
        _clientUnderTest = new BulkDataClient();
    }

    [Test]
    public async Task GetBulkDataListing()
    {
        var result = await _clientUnderTest.GetBulkDataListingAsync();

        result.Data.Length.Should().BeGreaterThanOrEqualTo(7);

        foreach (var bulkData in result.Data)
        {
            bulkData.JsonlDownloadUri.Host.Should().NotBe("localhost");
            bulkData.CompressedSize.Should().BeGreaterThan(0);
        }
    }

    [Test]
    public async Task GetBulkDataListingByType()
    {
        var result = await _clientUnderTest.GetBulkDataListingByTypeAsync(BulkTypes.OracleCards);

        result.Type.Should().Be(BulkTypes.OracleCards);
        result.JsonlDownloadUri.Host.Should().NotBe("localhost");
        result.CompressedSize.Should().BeGreaterThan(0);
    }

    [Test]
    public async Task GetBulkDataListingById()
    {
        var listing = await _clientUnderTest.GetBulkDataListingByTypeAsync(BulkTypes.OracleCards);

        var result = await _clientUnderTest.GetBulkDataListingByIdAsync(listing.Id);

        result.Should().BeEquivalentTo(listing);
    }
}
