using System.ComponentModel;
using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Colors
{
    [EnumMember(Value = "W")] [Description("Plains")] White = 1,
    [EnumMember(Value = "U")] [Description("Island")] Blue = 2,
    [EnumMember(Value = "B")] [Description("Swamp")] Black = 3,
    [EnumMember(Value = "R")] [Description("Mountain")] Red = 4,
    [EnumMember(Value = "G")] [Description("Forest")] Green = 5,
    [EnumMember(Value = "C")] [Description("Colorless")] Colorless = 6,
    [EnumMember(Value = "T")] [Description("Tap")] Tap = 7,
}