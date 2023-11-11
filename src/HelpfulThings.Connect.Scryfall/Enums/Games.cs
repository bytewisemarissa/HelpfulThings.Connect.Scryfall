using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Games
{
    [EnumMember(Value = "paper")] Paper = 0,
    [EnumMember(Value = "arena")] Arena = 1,
    [EnumMember(Value = "mtgo")] Mtgo = 2,
    [EnumMember(Value = "sega")] Sega = 3,
    [EnumMember(Value = "astral")] Astral = 4,
}