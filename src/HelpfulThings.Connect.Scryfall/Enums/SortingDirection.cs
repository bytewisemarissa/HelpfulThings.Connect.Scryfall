using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum SortingDirection
{
    [EnumMember(Value = "auto")] Auto,
    [EnumMember(Value = "asc")] Ascending,
    [EnumMember(Value = "desc")] Descending
}