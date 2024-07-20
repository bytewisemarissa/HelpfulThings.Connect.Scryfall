using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

public static class TestCards
{
    public static readonly Card BlackLotus1StEd = new Card()
    {
        ScryfallId = new Guid("b0faa7f2-b547-42c4-a810-839da50dadfe"),
        OracleId = new Guid("5089ec1a-f881-4d55-af14-5d996171203b"),
        MultiverseIds = new []{ 3 },
        MtgoId = 347,
        TcgPlayerId = 1042,
        CardmarketId = 5465,
        Name = "Black Lotus",
        Language = "en",
        ReleasedAt = new DateOnly(1993,8,5),
        ScryfallApiUri = new Uri("https://api.scryfall.com/cards/b0faa7f2-b547-42c4-a810-839da50dadfe"),
        ScryfallUri = new Uri("https://scryfall.com/card/lea/232/black-lotus?utm_source=api"),
        Layout = CardLayouts.Normal,
        HighResolutionScan = true,
        ImageStatus = ImageStatuses.HighResolution,
        ImageUris = new ImageUris()
        {
            Small = new Uri("https://cards.scryfall.io/small/front/b/0/b0faa7f2-b547-42c4-a810-839da50dadfe.jpg?1559591477"),
            Normal = new Uri("https://cards.scryfall.io/normal/front/b/0/b0faa7f2-b547-42c4-a810-839da50dadfe.jpg?1559591477"),
            Large = new Uri("https://cards.scryfall.io/large/front/b/0/b0faa7f2-b547-42c4-a810-839da50dadfe.jpg?1559591477"),
            Png = new Uri("https://cards.scryfall.io/png/front/b/0/b0faa7f2-b547-42c4-a810-839da50dadfe.png?1559591477"),
            ArtCrop = new Uri("https://cards.scryfall.io/art_crop/front/b/0/b0faa7f2-b547-42c4-a810-839da50dadfe.jpg?1559591477"),
            BorderCrop = new Uri("https://cards.scryfall.io/border_crop/front/b/0/b0faa7f2-b547-42c4-a810-839da50dadfe.jpg?1559591477")
        },
        ManaCost = "{0}",
        ConvertedManaCost = 0f,
        TypeLine = "Artifact",
        OracleText = "{T}, Sacrifice Black Lotus: Add three mana of any one color.",
        Colors = new Colors[0],
        ColorIdentities = new Colors[0],
        Keywords = new string[0],
        ProducedMana = new []
        {
            Colors.Black,
            Colors.Green,
            Colors.Red,
            Colors.Blue,
            Colors.White
        },
        Legalities = new FormatLegalities()
        {
            Standard = Legalities.NotLegal,
            Future = Legalities.NotLegal,
            Historic = Legalities.NotLegal,
            Gladiator = Legalities.NotLegal,
            Pioneer = Legalities.NotLegal,
            Explorer = Legalities.NotLegal,
            Modern = Legalities.NotLegal,
            Legacy = Legalities.Banned,
            Pauper = Legalities.NotLegal,
            Vintage = Legalities.Restricted,
            Penny = Legalities.NotLegal,
            Commander = Legalities.Banned,
            Oathbreaker = Legalities.Banned,
            Brawl = Legalities.NotLegal,
            StandardBrawl = Legalities.NotLegal,
            Alchemy = Legalities.NotLegal,
            PauperCommander = Legalities.NotLegal,
            Duel = Legalities.Banned,
            OldSchool = Legalities.Restricted,
            PreModern = Legalities.NotLegal,
            Predh = Legalities.Banned
        },
        Games = new []
        {
            Games.Paper,
            Games.Mtgo
        },
        ReserveList = true,
        Foil = false,
        NonFoil = true,
        Finishes = new []
        {
            Finishes.NonFoil
        },
        Oversized = false,
        Promo = false,
        Reprint = false,
        Variation = false,
        ScryfallSetId = new Guid("288bd996-960e-448b-a187-9504c1930c2c"),
        SetCode = "lea",
        SetName = "Limited Edition Alpha",
        SetType = SetTypes.Core,
        SetUri = new Uri("https://api.scryfall.com/sets/288bd996-960e-448b-a187-9504c1930c2c"),
        SetSearchUri = new Uri("https://api.scryfall.com/cards/search?order=set&q=e%3Alea&unique=prints"),
        ScryfallSetUri = new Uri("https://scryfall.com/sets/lea?utm_source=api"),
        RulingsUri = new Uri("https://api.scryfall.com/cards/b0faa7f2-b547-42c4-a810-839da50dadfe/rulings"),
        PrintsSearchUri = new Uri("https://api.scryfall.com/cards/search?order=released&q=oracleid%3A5089ec1a-f881-4d55-af14-5d996171203b&unique=prints"),
        CollectorNumber = "232",
        Digital = false,
        Rarity = CardRarities.Rare,
        BackDesignScryfallId = new Guid("0aeebaf5-8c7d-4636-9e82-8c27447861f7"),
        ArtistName = "Christopher Rush",
        ArtistIds = new []
        {
            new Guid("c96773f0-346c-4f7d-9271-2d98cc5d86e1")
        },
        IllustrationId = new Guid("54436824-977b-4dc7-8de1-8498e73e5ef2"),
        BorderColor = BorderColors.Black,
        Frame = Frames.NineteenNinetyThree,
        FullArt = false,
        Textless = false,
        FoundInBoosters = true,
        StorySpotlight = false,
        Prices = new CardPrices()
        {
            Usd = null,
            UsdFoil = null,
            UsdEtched = null,
            Eur = "12880.60",
            EurFoil = null,
            Tix = "471.25"
        },
        RelatedUris = new RelatedUris()
        {
            Gatherer = new Uri("https://gatherer.wizards.com/Pages/Card/Details.aspx?multiverseid=3&printed=false"),
            TcgPlayerInfiniteArticles = new Uri("https://tcgplayer.pxf.io/c/4931599/1830156/21018?subId1=api&trafcat=infinite&u=https%3A%2F%2Finfinite.tcgplayer.com%2Fsearch%3FcontentMode%3Darticle%26game%3Dmagic%26partner%3Dscryfall%26q%3DBlack%2BLotus"),
            TcgPlayerInfiniteDecks = new Uri("https://tcgplayer.pxf.io/c/4931599/1830156/21018?subId1=api&trafcat=infinite&u=https%3A%2F%2Finfinite.tcgplayer.com%2Fsearch%3FcontentMode%3Ddeck%26game%3Dmagic%26partner%3Dscryfall%26q%3DBlack%2BLotus"),
            Edhrec = new Uri("https://edhrec.com/route/?cc=Black+Lotus")
        },
        PurchaseUris = new PurchaseUris()
        {
            TcgPlayer = new Uri("https://tcgplayer.pxf.io/c/4931599/1830156/21018?subId1=api&u=https%3A%2F%2Fwww.tcgplayer.com%2Fproduct%2F1042%3Fpage%3D1"),
            CardMarket = new Uri("https://www.cardmarket.com/en/Magic/Products/Singles/Alpha/Black-Lotus?referrer=scryfall&utm_campaign=card_prices&utm_medium=text&utm_source=scryfall"),
            CardHoarder = new Uri("https://www.cardhoarder.com/cards/347?affiliate_id=scryfall&ref=card-profile&utm_campaign=affiliate&utm_medium=card&utm_source=scryfall")
        }
    };

    public static readonly Card DereviEmpyrialTactician = new Card()
    {
        ScryfallId = new Guid("3a1d0dad-18a8-489e-ac11-08f64b72fda4"),
        OracleId = new Guid("afa49a09-146f-4439-850e-dd1938c93cef"),
        MultiverseIds = new[] { 430395 },
        TcgPlayerId = 131911,
        CardmarketId = 298125,
        Name = "Derevi, Empyrial Tactician",
        Language = "en",
        ReleasedAt = new DateOnly(2017,6,9),
        ScryfallApiUri = new Uri("https://api.scryfall.com/cards/3a1d0dad-18a8-489e-ac11-08f64b72fda4"),
        ScryfallUri = new Uri("https://scryfall.com/card/cma/176/derevi-empyrial-tactician?utm_source=api"),
        Layout = CardLayouts.Normal,
        HighResolutionScan = true,
        ImageStatus = ImageStatuses.HighResolution,
        ImageUris = new ImageUris()
        {
            Small = new Uri(
                "https://cards.scryfall.io/small/front/3/a/3a1d0dad-18a8-489e-ac11-08f64b72fda4.jpg?1592673365"),
            Normal = new Uri(
                "https://cards.scryfall.io/normal/front/3/a/3a1d0dad-18a8-489e-ac11-08f64b72fda4.jpg?1592673365"),
            Large = new Uri(
                "https://cards.scryfall.io/large/front/3/a/3a1d0dad-18a8-489e-ac11-08f64b72fda4.jpg?1592673365"),
            Png = new Uri(
                "https://cards.scryfall.io/png/front/3/a/3a1d0dad-18a8-489e-ac11-08f64b72fda4.png?1592673365"),
            ArtCrop = new Uri(
                "https://cards.scryfall.io/art_crop/front/3/a/3a1d0dad-18a8-489e-ac11-08f64b72fda4.jpg?1592673365"),
            BorderCrop =
                new Uri(
                    "https://cards.scryfall.io/border_crop/front/3/a/3a1d0dad-18a8-489e-ac11-08f64b72fda4.jpg?1592673365")
        },
        ManaCost = "{G}{W}{U}",
        ConvertedManaCost = 3f,
        TypeLine = "Legendary Creature — Bird Wizard",
        OracleText =
            "Flying\nWhenever Derevi, Empyrial Tactician enters the battlefield or a creature you control deals combat damage to a player, you may tap or untap target permanent.\n{1}{G}{W}{U}: Put Derevi onto the battlefield from the command zone.",
        Power = "2",
        Toughness = "3",
        Colors = new[]
        {
            Colors.Green,
            Colors.Blue,
            Colors.White
        },
        ColorIdentities = new[]
        {
            Colors.Green,
            Colors.Blue,
            Colors.White
        },
        Keywords = new[]
        {
            "Flying"
        },
        Legalities = new FormatLegalities()
        {
            Standard = Legalities.NotLegal,
            Future = Legalities.NotLegal,
            Historic = Legalities.NotLegal,
            Gladiator = Legalities.NotLegal,
            Pioneer = Legalities.NotLegal,
            Explorer = Legalities.NotLegal,
            Modern = Legalities.NotLegal,
            Legacy = Legalities.Legal,
            Pauper = Legalities.NotLegal,
            Vintage = Legalities.Legal,
            Penny = Legalities.NotLegal,
            Commander = Legalities.Legal,
            Oathbreaker = Legalities.Legal,
            Brawl = Legalities.NotLegal,
            StandardBrawl = Legalities.NotLegal,
            Alchemy = Legalities.NotLegal,
            PauperCommander = Legalities.NotLegal,
            Duel = Legalities.Restricted,
            OldSchool = Legalities.NotLegal,
            PreModern = Legalities.NotLegal,
            Predh = Legalities.NotLegal
        },
        Games = new[]
        {
            Games.Paper
        },
        ReserveList = false,
        Foil = true,
        NonFoil = false,
        Finishes = new[]
        {
            Finishes.Foil
        },
        Oversized = false,
        Promo = false,
        Reprint = true,
        Variation = false,
        ScryfallSetId = new Guid("fd4d8463-0156-4c60-a40e-778762bb90e4"),
        SetCode = "cma",
        SetName = "Commander Anthology",
        SetType = SetTypes.Commander,
        SetUri = new Uri("https://api.scryfall.com/sets/fd4d8463-0156-4c60-a40e-778762bb90e4"),
        SetSearchUri = new Uri("https://api.scryfall.com/cards/search?order=set&q=e%3Acma&unique=prints"),
        ScryfallSetUri = new Uri("https://scryfall.com/sets/cma?utm_source=api"),
        RulingsUri = new Uri("https://api.scryfall.com/cards/3a1d0dad-18a8-489e-ac11-08f64b72fda4/rulings"),
        PrintsSearchUri =
            new Uri(
                "https://api.scryfall.com/cards/search?order=released&q=oracleid%3Aafa49a09-146f-4439-850e-dd1938c93cef&unique=prints"),
        CollectorNumber = "176",
        Digital = false,
        Rarity = CardRarities.Mythic,
        BackDesignScryfallId = new Guid("0aeebaf5-8c7d-4636-9e82-8c27447861f7"),
        ArtistName = "Michael Komarck",
        ArtistIds = new[]
        {
            new Guid("96a53b95-fe5f-4fbb-9411-ccf4ee150aca")
        },
        IllustrationId = new Guid("f3e4c9f8-681b-4afa-8603-4cdccb047c55"),
        BorderColor = BorderColors.Black,
        Frame = Frames.TwoThousandFifteen,
        SecurityStamp = SecurityStamps.Oval,
        FullArt = false,
        Textless = false,
        FoundInBoosters = false,
        StorySpotlight = false,
        EdhrecRank = 3163,
        Prices = new CardPrices()
        {
            Usd = null,
            UsdFoil = "13.91",
            UsdEtched = null,
            Eur = null,
            EurFoil = "3.90",
            Tix = null
        },
        RelatedUris = new RelatedUris()
        {
            Gatherer = new Uri("https://gatherer.wizards.com/Pages/Card/Details.aspx?multiverseid=430395&printed=false"),
            TcgPlayerInfiniteArticles =
                new Uri(
                    "https://tcgplayer.pxf.io/c/4931599/1830156/21018?subId1=api&trafcat=infinite&u=https%3A%2F%2Finfinite.tcgplayer.com%2Fsearch%3FcontentMode%3Darticle%26game%3Dmagic%26partner%3Dscryfall%26q%3DDerevi%252C%2BEmpyrial%2BTactician"),
            TcgPlayerInfiniteDecks =
                new Uri(
                    "https://tcgplayer.pxf.io/c/4931599/1830156/21018?subId1=api&trafcat=infinite&u=https%3A%2F%2Finfinite.tcgplayer.com%2Fsearch%3FcontentMode%3Ddeck%26game%3Dmagic%26partner%3Dscryfall%26q%3DDerevi%252C%2BEmpyrial%2BTactician"),
            Edhrec = new Uri("https://edhrec.com/route/?cc=Derevi%2C+Empyrial+Tactician")
        },
        PurchaseUris = new PurchaseUris()
        {
            TcgPlayer = new Uri(
                "https://tcgplayer.pxf.io/c/4931599/1830156/21018?subId1=api&u=https%3A%2F%2Fwww.tcgplayer.com%2Fproduct%2F131911%3Fpage%3D1"),
            CardMarket =
                new Uri(
                    "https://www.cardmarket.com/en/Magic/Products/Singles/Commander-Anthology/Derevi-Empyrial-Tactician?referrer=scryfall&utm_campaign=card_prices&utm_medium=text&utm_source=scryfall"),
            CardHoarder =
                new Uri(
                    "https://www.cardhoarder.com/cards?affiliate_id=scryfall&data%5Bsearch%5D=Derevi%2C+Empyrial+Tactician&ref=card-profile&utm_campaign=affiliate&utm_medium=card&utm_source=scryfall")
        }
    };
}