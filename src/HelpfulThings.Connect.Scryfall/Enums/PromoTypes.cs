using System.ComponentModel;
using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum PromoTypes
{
    [EnumMember(Value = "planeswalkerdeck")] [Description("Planeswalker Deck")] PlaneswalkerDeck = 1,
    [EnumMember(Value = "promopack")] [Description("Promo Pack")] PromoPack = 2,
    [EnumMember(Value = "stamped")] [Description("Stamped")] Stamped = 3,
    [EnumMember(Value = "boosterfun")] [Description("Booster Fun")] BoosterFun = 4,
    [EnumMember(Value = "mediainsert")] [Description("Media Insert")] MediaInsert = 5,
    [EnumMember(Value = "playerrewards")] [Description("Player Rewards")] PlayerRewards = 6,
    [EnumMember(Value = "release")] [Description("Release")] Release = 7,
    [EnumMember(Value = "setpromo")] [Description("Set Promo")] SetPromo = 8,
    [EnumMember(Value = "prerelease")] [Description("Pre-release")] PreRelease = 9,
    [EnumMember(Value = "datestamped")] [Description("Date Stamped")] DateStamped = 10,
    [EnumMember(Value = "surgefoil")] [Description("Surge Foil")] SurgeFoil = 11,
    [EnumMember(Value = "schinesealtart")] [Description("Safe Chinese Alt Art")] SafeChineseAltArt = 12,
    [EnumMember(Value = "event")] [Description("Event")] Event = 13,
    [EnumMember(Value = "tourney")] [Description("Tournement")] Tourney = 14,
    [EnumMember(Value = "fnm")] [Description("Friday Night Magic")] Fnm = 15,
    [EnumMember(Value = "gameday")] [Description("Game Day")] GameDay = 16,
    [EnumMember(Value = "themepack")] [Description("Theme Pack")] ThemePack = 17,
    [EnumMember(Value = "draculaseries")] [Description("Dracula Series")] DraculaSeries = 18,
    [EnumMember(Value = "buyabox")] [Description("Buy-A-Box")] BuyABox = 19,
    [EnumMember(Value = "bundle")] [Description("Bundle")] Bundle = 20,
    [EnumMember(Value = "halofoil")] [Description("Halo Foil")] HaloFoil = 21,
    [EnumMember(Value = "galaxyfoil")] [Description("Galaxy Foil")] GalaxyFoil = 22,
    [EnumMember(Value = "alchemy")] [Description("Alchemy")] Alchemy = 23,
    [EnumMember(Value = "godzillaseries")] [Description("Godzilla Series")] Godzilla = 24,
    [EnumMember(Value = "starterdeck")] [Description("Starter Deck")] StarterDeck = 25,
    [EnumMember(Value = "arenaleague")] [Description("Arena League")] ArenaLeague = 26,
    [EnumMember(Value = "rebalanced")] [Description("Rebalanced")] Rebalanced = 27,
    [EnumMember(Value = "convention")] [Description("convention")] Convention = 28,
    [EnumMember(Value = "textured")] [Description("textured")] Textured = 29,
    [EnumMember(Value = "judgegift")] [Description("Judge Gift")] JudgeGift = 30,
    [EnumMember(Value = "embossed")] [Description("Embossed")] Embossed = 31,
    [EnumMember(Value = "instore")] [Description("In Store")] InStore = 32,
    [EnumMember(Value = "serialized")] [Description("Serialized")] Serialized = 33,
    [EnumMember(Value = "doublerainbow")] [Description("Double Rainbow")] DoubleRainbow = 34,
    [EnumMember(Value = "premiereshop")] [Description("Premiere Shop")] PremiereShop = 35,
    [EnumMember(Value = "confettifoil")] [Description("Confetti Foil")] ConfettiFoil = 36,
    [EnumMember(Value = "wizardsplaynetwork")] [Description("Wizard's Play Network")] WizardsPlayNetwork = 37,
    [EnumMember(Value = "boxtopper")] [Description("Box Topper")] BoxTopper = 38,
    [EnumMember(Value = "stepandcompleat")] [Description("Step and Compleat")] StepAndCompleat = 39,
    [EnumMember(Value = "intropack")] [Description("Intro Pack")] IntroPack = 40,
    [EnumMember(Value = "silverfoil")] [Description("Silver Foil")] SilverFoil = 41,
    [EnumMember(Value = "oilslick")] [Description("Oil Slick")] OilSlick = 42,
    [EnumMember(Value = "brawldeck")] [Description("Brawl Deck")] BrawlDeck = 43,
    [EnumMember(Value = "thick")] [Description("Thick")] Thick = 44,
    [EnumMember(Value = "giftbox")] [Description("Gift Box")] GiftBox = 45,
    [EnumMember(Value = "league")] [Description("League")] League = 46,
    [EnumMember(Value = "duels")] [Description("Duels")] Duels = 47,
    [EnumMember(Value = "gilded")] [Description("Gilded")] Gilded = 48,
    [EnumMember(Value = "neonink")] [Description("Neon Ink")] NeonInk = 49,
    [EnumMember(Value = "jpwalker")] [Description("JP Walker")] JpWalker = 50,
    [EnumMember(Value = "moonlitland")] [Description("Moon Lit Land")] MoonLitLand = 51,
    [EnumMember(Value = "plastic")] [Description("Plastic")] Plastic = 52,
    [EnumMember(Value = "playpromo")] [Description("Play Promo")] PlayPromo = 53,
    [EnumMember(Value = "storechampionship")] [Description("Store Championship")] StoreChampionship = 54,
    [EnumMember(Value = "commanderparty")] [Description("Commander Party")] CommanderParty = 55,
    [EnumMember(Value = "openhouse")] [Description("Open House")] OpenHouse = 56,
    [EnumMember(Value = "glossy")] [Description("Glossy")] Glossy = 57,
    [EnumMember(Value = "setextension")] [Description("Set Extension")] SetExtension = 58,
    [EnumMember(Value = "bringafrind")] [Description("Bring a Friend")] BringAFriend = 59,
    [EnumMember(Value = "concept")] [Description("Concept")] Concept = 60,
    [EnumMember(Value = "draftweekend")] [Description("Draft Weekend")] DraftWeekend = 61,
    [EnumMember(Value = "OK")] [Description("OK")] Ok = 62,
    [EnumMember(Value = "poster")] [Description("Poster")] Poster = 63,
}