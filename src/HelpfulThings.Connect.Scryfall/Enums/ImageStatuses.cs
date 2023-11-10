using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum ImageStatuses
{
    [EnumMember(Value = "missing")] Missing = 0,
    [EnumMember(Value = "placeholder")] Placeholder = 1,
    [EnumMember(Value = "lowres")] LowResolution = 2,
    [EnumMember(Value = "highres_scan")] HighResolution = 3,
}