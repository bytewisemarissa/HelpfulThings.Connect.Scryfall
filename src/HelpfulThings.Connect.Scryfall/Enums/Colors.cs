using System.ComponentModel;
using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Colors
{
    [EnumMember(Value = "W")] [Description("Plains")] White,
    [EnumMember(Value = "U")] [Description("Island")] Blue,
    [EnumMember(Value = "B")] [Description("Swamp")] Black,
    [EnumMember(Value = "R")] [Description("Mountain")] Red,
    [EnumMember(Value = "G")] [Description("Forest")] Green,
    [EnumMember(Value = "C")] [Description("Colorless")] Colorless,
}