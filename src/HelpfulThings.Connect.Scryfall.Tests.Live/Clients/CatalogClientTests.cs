using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Enums;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.Clients;

public class CatalogClientTests
{
    private CatalogClient _clientUnderTest;
    
    [SetUp]
    public void Setup()
    {
        _clientUnderTest = new CatalogClient();
    }

    [Test]
    public async Task FlexCatalogs()
    {
        foreach (CatalogTypes type in Enum.GetValuesAsUnderlyingType(typeof(CatalogTypes)))
        {
            var results = await _clientUnderTest.GetCatalogByTypeAsync(type);

            results.TotalValues.Should().BeGreaterThan(0);
            results.TotalValues.Should().Be(results.Data.Count);
        }
    }
}