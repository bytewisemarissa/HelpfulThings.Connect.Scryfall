using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum UniqueModes
{
    [EnumMember(Value = "cards")] Cards,
    [EnumMember(Value = "art")] Art,
    [EnumMember(Value = "prints")] Prints
}