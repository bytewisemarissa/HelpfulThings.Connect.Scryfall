using System.ComponentModel;
using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum PromoTypes
{
    [EnumMember(Value = "planeswalkerdeck")] [Description("Planeswalker Deck")] PlaneswalkerDeck = 0,
    [EnumMember(Value = "promopack")] [Description("Promo Pack")] PromoPack = 1,
    [EnumMember(Value = "stamped")] [Description("Stamped")] Stamped = 2,
    [EnumMember(Value = "boosterfun")] [Description("Booster Fun")] BoosterFun = 3,
    [EnumMember(Value = "mediainsert")] [Description("Media Insert")] MediaInsert = 4,
    [EnumMember(Value = "playerrewards")] [Description("Player Rewards")] PlayerRewards = 5,
    [EnumMember(Value = "release")] [Description("Release")] Release = 6,
    [EnumMember(Value = "setpromo")] [Description("Set Promo")] SetPromo = 7,
    [EnumMember(Value = "prerelease")] [Description("Pre-release")] PreRelease = 8,
    [EnumMember(Value = "datestamped")] [Description("Date Stamped")] DateStamped = 9,
    [EnumMember(Value = "surgefoil")] [Description("Surge Foil")] SurgeFoil = 10,
    [EnumMember(Value = "schinesealtart")] [Description("Safe Chinese Alt Art")] SafeChineseAltArt = 11,
    [EnumMember(Value = "event")] [Description("Event")] Event = 12,
    [EnumMember(Value = "tourney")] [Description("Tournement")] Tourney = 13,
    [EnumMember(Value = "fnm")] [Description("Friday Night Magic")] Fnm = 14,
    [EnumMember(Value = "gameday")] [Description("Game Day")] GameDay = 15,
    [EnumMember(Value = "themepack")] [Description("Theme Pack")] ThemePack = 16,
    [EnumMember(Value = "draculaseries")] [Description("Dracula Series")] DraculaSeries = 17,
    [EnumMember(Value = "buyabox")] [Description("Buy-A-Box")] BuyABox = 18,
    [EnumMember(Value = "bundle")] [Description("Bundle")] Bundle = 19,
    [EnumMember(Value = "halofoil")] [Description("Halo Foil")] HaloFoil = 20,
    [EnumMember(Value = "galaxyfoil")] [Description("Galaxy Foil")] GalaxyFoil = 21,
    [EnumMember(Value = "alchemy")] [Description("Alchemy")] Alchemy = 22,
    [EnumMember(Value = "godzillaseries")] [Description("Godzilla Series")] Godzilla = 23,
    [EnumMember(Value = "starterdeck")] [Description("Starter Deck")] StarterDeck = 24,
    [EnumMember(Value = "arenaleague")] [Description("Arena League")] ArenaLeague = 25,
    [EnumMember(Value = "rebalanced")] [Description("Rebalanced")] Rebalanced = 26,
    [EnumMember(Value = "convention")] [Description("convention")] Convention = 27,
    [EnumMember(Value = "textured")] [Description("textured")] Textured = 28,
    [EnumMember(Value = "judgegift")] [Description("Judge Gift")] JudgeGift = 28,
    [EnumMember(Value = "embossed")] [Description("Embossed")] Embossed = 29,
    [EnumMember(Value = "instore")] [Description("In Store")] InStore = 30,
    [EnumMember(Value = "serialized")] [Description("Serialized")] Serialized = 31,
    [EnumMember(Value = "doublerainbow")] [Description("Double Rainbow")] DoubleRainbow = 32,
    [EnumMember(Value = "premiereshop")] [Description("Premiere Shop")] PremiereShop = 33,
    [EnumMember(Value = "confettifoil")] [Description("Confetti Foil")] ConfettiFoil = 34,
    [EnumMember(Value = "wizardsplaynetwork")] [Description("Wizard's Play Network")] WizardsPlayNetwork = 35,
    [EnumMember(Value = "boxtopper")] [Description("Box Topper")] BoxTopper = 36,
    [EnumMember(Value = "stepandcompleat")] [Description("Step and Compleat")] StepAndCompleat = 37,
    [EnumMember(Value = "intropack")] [Description("Intro Pack")] IntroPack = 38,
    [EnumMember(Value = "silverfoil")] [Description("Silver Foil")] SilverFoil = 39,
    [EnumMember(Value = "oilslick")] [Description("Oil Slick")] OilSlick = 40,
    [EnumMember(Value = "brawldeck")] [Description("Brawl Deck")] BrawlDeck = 41,
    [EnumMember(Value = "thick")] [Description("Thick")] Thick = 42,
    [EnumMember(Value = "giftbox")] [Description("Gift Box")] GiftBox = 43,
    [EnumMember(Value = "league")] [Description("League")] League = 44,
    [EnumMember(Value = "duels")] [Description("Duels")] Duels = 45,
    [EnumMember(Value = "gilded")] [Description("Gilded")] Gilded = 46,
    [EnumMember(Value = "neonink")] [Description("Neon Ink")] NeonInk = 47,
    [EnumMember(Value = "jpwalker")] [Description("JP Walker")] JpWalker = 48,
    [EnumMember(Value = "moonlitland")] [Description("Moon Lit Land")] MoonLitLand = 49,
    [EnumMember(Value = "plastic")] [Description("Plastic")] Plastic = 50,
    [EnumMember(Value = "playpromo")] [Description("Play Promo")] PlayPromo = 51,
    [EnumMember(Value = "storechampionship")] [Description("Store Championship")] StoreChampionship = 52,
    [EnumMember(Value = "commanderparty")] [Description("Commander Party")] CommanderParty = 53,
}