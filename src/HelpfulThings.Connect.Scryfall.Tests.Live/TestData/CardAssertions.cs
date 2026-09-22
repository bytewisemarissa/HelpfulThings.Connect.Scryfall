using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

public static class CardAssertions
{
    private static void AssertMatchesStableFields(Card card, StableCardFields expected) =>
        card.Should().BeEquivalentTo(expected, o => o.ExcludingMissingMembers());

    public static void AssertIsBlackLotusAlpha(Card card) =>
        AssertMatchesStableFields(card, TestCards.BlackLotus1StEd);

    public static void AssertIsDereviEmpyrialTactician(Card card) =>
        AssertMatchesStableFields(card, TestCards.DereviEmpyrialTactician);

    public static void AssertIsLlanowarElvesArenaPrinting(Card card) =>
        AssertMatchesStableFields(card, TestCards.LlanowarElvesArena);
}
