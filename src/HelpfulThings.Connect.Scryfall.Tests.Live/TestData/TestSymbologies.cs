using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

public static class TestSymbologies
{
    public static CardSymbol Tap = new CardSymbol()
    {
        Symbol = "{T}",
        SvgUri = new Uri("https://svgs.scryfall.io/card-symbols/T.svg"),
        LooseVariant = null,
        English = "tap this permanent",
        Transposable = false,
        AppearsInManaCosts = false,
        ManaValue = 0f,
        ConvertedManaCost = 0f,
        Funny = false,
        Colors = Array.Empty<Colors>(),
        GathererAlternates = new[] { "ocT", "oT" }
    };
}