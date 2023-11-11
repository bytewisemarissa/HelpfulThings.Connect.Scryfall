using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Games
{
    [EnumMember(Value = "paper")] Paper = 1,
    [EnumMember(Value = "arena")] Arena = 2,
    [EnumMember(Value = "mtgo")] Mtgo = 3,
    [EnumMember(Value = "sega")] Sega = 4,
    [EnumMember(Value = "astral")] Astral = 5,
}