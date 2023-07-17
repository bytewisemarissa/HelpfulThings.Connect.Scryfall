using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Games
{
    [EnumMember(Value = "paper")] Paper,
    [EnumMember(Value = "arena")] Arena,
    [EnumMember(Value = "mtgo")] Mtgo
}