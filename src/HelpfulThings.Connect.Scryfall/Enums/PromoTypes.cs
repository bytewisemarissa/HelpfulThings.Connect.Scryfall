using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum PromoTypes
{
    [EnumMember(Value = "planeswalkerdeck")] PlaneswalkerDeck,
    [EnumMember(Value = "promopack")] PromoPack,
    [EnumMember(Value = "stamped")] Stamped,
    [EnumMember(Value = "boosterfun")] BoosterFun,
    [EnumMember(Value = "mediainsert")] MediaInsert,
    [EnumMember(Value = "playerrewards")] PlayerRewards,
    [EnumMember(Value = "release")] Release,
    [EnumMember(Value = "setpromo")] SetPromo,
    [EnumMember(Value = "prerelease")] PreRelease,
    [EnumMember(Value = "datestamped")] DateStamped,
    [EnumMember(Value = "surgefoil")] SurgeFoil,
    [EnumMember(Value = "schinesealtart")] SafeChineseAltArt,
    [EnumMember(Value = "event")] Event,
    [EnumMember(Value = "tourney")] Tourney,
    [EnumMember(Value = "fnm")] Fnm,
    [EnumMember(Value = "gameday")] GameDay,
    [EnumMember(Value = "themepack")] ThemePack,
    [EnumMember(Value = "draculaseries")] DraculaSeries,
    [EnumMember(Value = "buyabox")] BuyABox,
    [EnumMember(Value = "bundle")] Bundle,
    [EnumMember(Value = "halofoil")] HaloFoil,
    [EnumMember(Value = "galaxyfoil")] GalaxyFoil,
    [EnumMember(Value = "alchemy")] Alchemy
}