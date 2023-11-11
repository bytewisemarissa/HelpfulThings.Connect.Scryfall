using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum SecurityStamps
{
    [EnumMember(Value = "oval")] Oval = 1,
    [EnumMember(Value = "triangle")] Triangle = 2,
    [EnumMember(Value = "acorn")] Acorn = 3,
    [EnumMember(Value = "circle")] Circle = 4,
    [EnumMember(Value = "arena")] Arena = 5,
    [EnumMember(Value = "heart")] Heart = 6
}