using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Clients.ApiClients;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.Clients;

[Category("Live")]
public class MigrationsClientTests
{
    private MigrationsClient _clientUnderTest;

    [SetUp]
    public void Setup()
    {
        _clientUnderTest = new MigrationsClient();
    }

    [Test]
    public async Task ListMigrations()
    {
        var result = await _clientUnderTest.ListMigrationsAsync();

        result.Data.Length.Should().BeGreaterThan(0);
    }

    [Test]
    public async Task GetMigration()
    {
        var listing = await _clientUnderTest.ListMigrationsAsync();
        var expected = listing.Data.First();

        var result = await _clientUnderTest.GetMigrationAsync(expected.Id);

        result.Should().BeEquivalentTo(expected);
    }
}
