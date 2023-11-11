using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum BorderColors
{
    [EnumMember(Value = "black")] Black = 1,
    [EnumMember(Value = "white")] White = 2,
    [EnumMember(Value = "borderless")] Borderless = 3,
    [EnumMember(Value = "silver")] Silver = 4,
    [EnumMember(Value = "gold")] Gold = 5,
}