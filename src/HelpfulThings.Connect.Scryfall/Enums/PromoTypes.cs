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
}