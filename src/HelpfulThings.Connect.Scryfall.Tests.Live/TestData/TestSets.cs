using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

public static class TestSets
{
    public static Set CommanderMasters = new Set()
    {
        ScryfallId = new Guid("cd05036f-2698-43e6-a48e-5c8d82f0a551"),
        Code = "cmm",
        MtgoCode = "cmm",
        ArenaCode = "cmm",
        TcgPlayerId = 23020,
        Name = "Commander Masters",
        SetApiLink = new Uri("https://api.scryfall.com/sets/cd05036f-2698-43e6-a48e-5c8d82f0a551"),
        ScryfallUri = new Uri("https://scryfall.com/sets/cmm"),
        SearchUri = new Uri(
            "https://api.scryfall.com/cards/search?include_extras=true&include_variations=true&order=set&q=e%3Acmm&unique=prints"),
        ReleasedAt = Convert.ToDateTime("2023-08-04"),
        SetType = SetTypes.Masters,
        CardCount = 1067,
        Digital = false,
        NonFoilOnly = false,
        FoilOnly = false,
        BlockCode = "cmd",
        Block = "Commander",
        IconSvgUri = new Uri("https://svgs.scryfall.io/sets/cmm.svg?1721016000")
    };

    public static Set CommanderAnthology = new Set()
    {
        ScryfallId = new Guid("fd4d8463-0156-4c60-a40e-778762bb90e4"),
        Code = "cma",
        TcgPlayerId = 1933,
        Name = "Commander Anthology",
        SetApiLink = new Uri("https://api.scryfall.com/sets/fd4d8463-0156-4c60-a40e-778762bb90e4"),
        ScryfallUri = new Uri("https://scryfall.com/sets/cma"),
        SearchUri = new Uri(
            "https://api.scryfall.com/cards/search?include_extras=true&include_variations=true&order=set&q=e%3Acma&unique=prints"),
        ReleasedAt = Convert.ToDateTime("2017-06-09"),
        SetType = SetTypes.Commander,
        CardCount = 320,
        Digital = false,
        NonFoilOnly = false,
        FoilOnly = false,
        BlockCode = "cmd",
        Block = "Commander",
        IconSvgUri = new Uri("https://svgs.scryfall.io/sets/cma.svg?1721016000")
    };
}