using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum BorderColors
{
    [EnumMember(Value = "black")] Black,
    [EnumMember(Value = "white")] White,
    [EnumMember(Value = "borderless")] Borderless,
    [EnumMember(Value = "silver")] Silver,
    [EnumMember(Value = "gold")] Gold,
}