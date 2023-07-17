using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum ImageStatuses
{
    [EnumMember(Value = "missing")] Missing,
    [EnumMember(Value = "placeholder")] Placeholder,
    [EnumMember(Value = "lowres")] LowResolution,
    [EnumMember(Value = "highres_scan")] HighResolution,
}