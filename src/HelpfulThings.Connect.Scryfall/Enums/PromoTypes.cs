using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum PromoTypes
{
    [EnumMember(Value = "planeswalkerdeck")] PlaneswalkerDeck = 0,
    [EnumMember(Value = "promopack")] PromoPack = 1,
    [EnumMember(Value = "stamped")] Stamped = 2,
    [EnumMember(Value = "boosterfun")] BoosterFun = 3,
    [EnumMember(Value = "mediainsert")] MediaInsert = 4,
    [EnumMember(Value = "playerrewards")] PlayerRewards = 5,
    [EnumMember(Value = "release")] Release = 6,
    [EnumMember(Value = "setpromo")] SetPromo = 7,
    [EnumMember(Value = "prerelease")] PreRelease = 8,
    [EnumMember(Value = "datestamped")] DateStamped = 9,
    [EnumMember(Value = "surgefoil")] SurgeFoil = 10,
    [EnumMember(Value = "schinesealtart")] SafeChineseAltArt = 11,
    [EnumMember(Value = "event")] Event = 12,
    [EnumMember(Value = "tourney")] Tourney = 13,
    [EnumMember(Value = "fnm")] Fnm = 14,
    [EnumMember(Value = "gameday")] GameDay = 15,
    [EnumMember(Value = "themepack")] ThemePack = 16,
    [EnumMember(Value = "draculaseries")] DraculaSeries = 17,
    [EnumMember(Value = "buyabox")] BuyABox = 18,
    [EnumMember(Value = "bundle")] Bundle = 19,
    [EnumMember(Value = "halofoil")] HaloFoil = 20,
    [EnumMember(Value = "galaxyfoil")] GalaxyFoil = 21,
    [EnumMember(Value = "alchemy")] Alchemy = 22,
    [EnumMember(Value = "godzillaseries")] Godzilla = 23,
    [EnumMember(Value = "starterdeck")] StarterDeck = 24,
}