using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Legalities
{
    [EnumMember(Value = "legal")] Legal = 1,
    [EnumMember(Value = "not_legal")] NotLegal = 2,
    [EnumMember(Value = "restricted")] Restricted = 3,
    [EnumMember(Value = "banned")] Banned = 4,
}