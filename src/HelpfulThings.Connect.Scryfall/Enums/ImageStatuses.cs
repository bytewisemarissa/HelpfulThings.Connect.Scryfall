using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum ImageStatuses
{
    [EnumMember(Value = "missing")] Missing = 1,
    [EnumMember(Value = "placeholder")] Placeholder = 2,
    [EnumMember(Value = "lowres")] LowResolution = 3,
    [EnumMember(Value = "highres_scan")] HighResolution = 4,
}