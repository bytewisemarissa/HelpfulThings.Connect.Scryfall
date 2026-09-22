using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;
using HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.Clients;

[Category("Live")]
public class SetsClientTests
{
    private SetsClient _clientUnderTest;

    [SetUp]
    public void Setup()
    {
        _clientUnderTest = new SetsClient();
    }

    [Test]
    public async Task ListSets()
    {
        var setsResults = await _clientUnderTest.ListSets();

        Assert.IsTrue(setsResults.Data.Length > 0);
        Assert.IsTrue(setsResults.Warnings == null);
    }

    [Test]
    public async Task GetSetByCodeCommanderMasters()
    {
        var set = await _clientUnderTest.GetSetByCode(TestSets.CommanderMasters.Code);

        SetAssertions.AssertIsCommanderMasters(set);
    }

    [Test]
    public async Task GetSetByTcgPlayerIdCommanderMasters()
    {
        var set = await _clientUnderTest.GetSetByTcgPlayerId(TestSets.CommanderMasters.TcgPlayerId);

        SetAssertions.AssertIsCommanderMasters(set);
    }

    [Test]
    public async Task GetSetsByScryfallIdCommanderMasters()
    {
        var set = await _clientUnderTest.GetSetByScryfallId(TestSets.CommanderMasters.ScryfallId);

        SetAssertions.AssertIsCommanderMasters(set);
    }

    [Test]
    public async Task GetSetByCodeCommanderAnthology()
    {
        var set = await _clientUnderTest.GetSetByCode(TestSets.CommanderAnthology.Code);

        SetAssertions.AssertIsCommanderAnthology(set);
    }

    [Test]
    public async Task GetSetByTcgPlayerIdCommanderAnthology()
    {
        var set = await _clientUnderTest.GetSetByTcgPlayerId(TestSets.CommanderAnthology.TcgPlayerId);

        SetAssertions.AssertIsCommanderAnthology(set);
    }

    [Test]
    public async Task GetSetsByScryfallIdCommanderAnthology()
    {
        var set = await _clientUnderTest.GetSetByScryfallId(TestSets.CommanderAnthology.ScryfallId);

        SetAssertions.AssertIsCommanderAnthology(set);
    }
}
