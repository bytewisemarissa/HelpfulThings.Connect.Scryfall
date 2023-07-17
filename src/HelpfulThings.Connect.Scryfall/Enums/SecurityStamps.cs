using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum SecurityStamps
{
    [EnumMember(Value = "oval")] Oval,
    [EnumMember(Value = "triangle")] Triangle,
    [EnumMember(Value = "acorn")] Acorn,
    [EnumMember(Value = "circle")] Circle,
    [EnumMember(Value = "arena")] Arena,
    [EnumMember(Value = "heart")] Heart
}