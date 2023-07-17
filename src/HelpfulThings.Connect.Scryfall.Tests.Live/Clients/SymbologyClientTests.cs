using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.Clients;

public class SymbologyClientTests
{
    private SymbologyClient _clientUnderTest;

    [SetUp]
    public void Setup()
    {
        _clientUnderTest = new SymbologyClient();
    }

    [Test]
    public async Task GetAll()
    {
        var results = await _clientUnderTest.GetSymbologyAsync();

        results.HasMore.Should().BeFalse();
        results.Data.Should().NotBeNull();
        results.Data.Length.Should().BeGreaterThan(0);

        var selectedResult = results.Data.Single(cs => cs.Symbol == TestSymbologies.Tap.Symbol);

        selectedResult.Should().BeEquivalentTo(TestSymbologies.Tap);
    }

    [Test]
    public async Task ParseMana()
    {
        var results = await _clientUnderTest.ParseManaCostAsync("2{g}2");

        results.Cost.Should().Be("{4}{G}");
        results.Colors.Length.Should().Be(1);
        results.Colors[0].Should().Be(Colors.Green);
        results.Colorless = false;
        results.MonoColor = true;
        results.MultiColored = false;
    }
}