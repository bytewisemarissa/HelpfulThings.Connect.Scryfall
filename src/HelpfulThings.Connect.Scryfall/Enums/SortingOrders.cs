using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum SortingOrders
{
    [EnumMember(Value = "name")] Name,
    [EnumMember(Value = "set")] Set,
    [EnumMember(Value = "released")] Released,
    [EnumMember(Value = "rarity")] Rarity,
    [EnumMember(Value = "color")] Color,
    [EnumMember(Value = "usd")] UsdPrice,
    [EnumMember(Value = "cmc")] ConvertedManaCost,
    [EnumMember(Value = "power")] Power,
    [EnumMember(Value = "toughness")] Toughness,
    [EnumMember(Value = "edhrec")] EdhrecRanking,
    [EnumMember(Value = "penny")] PennyDreadfulRanking,
    [EnumMember(Value = "artist")] ArtistName,
    [EnumMember(Value = "review")] ReviewScore
}