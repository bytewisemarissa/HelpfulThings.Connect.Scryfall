using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Models;
using HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.Clients;

public class RulingsClientTests
{
    private RulingsClient _clientUnderTest;

    [SetUp]
    public void Setup()
    {
        _clientUnderTest = new RulingsClient();
    }

    [Test]
    public async Task GetMultiverseCardRulings()
    {
        var result = await 
            _clientUnderTest.GetMultiverseCardRulingsAsync(TestCards.DereviEmpyrialTactician.MultiverseIds!.First());

        result.Warnings.Should().BeNull();
        result.Data.Should().BeEquivalentTo(TestRulings.Rulings[TestCards.DereviEmpyrialTactician.ScryfallId]);
        result.HasMore.Should().BeFalse();
        result.NextPage.Should().BeNull();
        result.HostedType.Should().Be(typeof(Ruling));
    }

    /*
    [Test]
    public async Task GetMtgoCardRulings()
    {
        var result = await 
            _clientUnderTest.GetMtgoCardRulingsAsync(TestCards.DereviEmpyrialTactician.MultiverseIds!.First());

        result.Warnings.Should().BeNull();
        result.Data.Should().BeEquivalentTo(TestRulings.Rulings[TestCards.DereviEmpyrialTactician.ScryfallId]);
        result.HasMore.Should().BeFalse();
        result.NextPage.Should().BeNull();
        result.HostedType.Should().Be(typeof(Ruling));
    }
    */
    
    [Test]
    public async Task GetSetCollectorNumberCardRulings()
    {
        var result = await 
            _clientUnderTest.GetRulingsBySetAndCollectorIdAsync(
                TestCards.DereviEmpyrialTactician.SetCode, 
                TestCards.DereviEmpyrialTactician.CollectorNumber
                );

        result.Warnings.Should().BeNull();
        result.Data.Should().BeEquivalentTo(TestRulings.Rulings[TestCards.DereviEmpyrialTactician.ScryfallId]);
        result.HasMore.Should().BeFalse();
        result.NextPage.Should().BeNull();
        result.HostedType.Should().Be(typeof(Ruling));
    }
    
    [Test]
    public async Task GetScryfallIdRulings()
    {
        var result = await 
            _clientUnderTest.GetRulingsByScryfallIdAsync(TestCards.DereviEmpyrialTactician.ScryfallId);

        result.Warnings.Should().BeNull();
        result.Data.Should().BeEquivalentTo(TestRulings.Rulings[TestCards.DereviEmpyrialTactician.ScryfallId]);
        result.HasMore.Should().BeFalse();
        result.NextPage.Should().BeNull();
        result.HostedType.Should().Be(typeof(Ruling));
    }
}