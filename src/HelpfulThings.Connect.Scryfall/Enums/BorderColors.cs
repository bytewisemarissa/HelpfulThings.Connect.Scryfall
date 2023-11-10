using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum BorderColors
{
    [EnumMember(Value = "black")] Black = 0,
    [EnumMember(Value = "white")] White = 1,
    [EnumMember(Value = "borderless")] Borderless = 2,
    [EnumMember(Value = "silver")] Silver = 3,
    [EnumMember(Value = "gold")] Gold = 4,
}