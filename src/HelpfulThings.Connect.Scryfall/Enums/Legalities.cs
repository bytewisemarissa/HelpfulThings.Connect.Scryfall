using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Legalities
{
    [EnumMember(Value = "legal")] Legal,
    [EnumMember(Value = "not_legal")] NotLegal,
    [EnumMember(Value = "restricted")] Restricted,
    [EnumMember(Value = "banned")] Banned,
}