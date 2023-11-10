using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Legalities
{
    [EnumMember(Value = "legal")] Legal = 0,
    [EnumMember(Value = "not_legal")] NotLegal = 1,
    [EnumMember(Value = "restricted")] Restricted = 2,
    [EnumMember(Value = "banned")] Banned = 3,
}