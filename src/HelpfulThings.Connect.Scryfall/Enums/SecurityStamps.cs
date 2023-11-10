using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum SecurityStamps
{
    [EnumMember(Value = "oval")] Oval = 0,
    [EnumMember(Value = "triangle")] Triangle = 1,
    [EnumMember(Value = "acorn")] Acorn = 2,
    [EnumMember(Value = "circle")] Circle = 3,
    [EnumMember(Value = "arena")] Arena = 4,
    [EnumMember(Value = "heart")] Heart = 5
}