using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

public static class SetAssertions
{
    private static void AssertMatchesStableFields(Set set, StableSetFields expected) =>
        set.Should().BeEquivalentTo(expected, o => o.ExcludingMissingMembers());

    public static void AssertIsCommanderMasters(Set set) =>
        AssertMatchesStableFields(set, TestSets.CommanderMasters);

    public static void AssertIsCommanderAnthology(Set set) =>
        AssertMatchesStableFields(set, TestSets.CommanderAnthology);
}
