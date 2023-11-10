using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Frames
{
    [EnumMember(Value = "1993")] NineteenNinetyThree = 0,
    [EnumMember(Value = "1997")] NineteenNinetySeven = 1,
    [EnumMember(Value = "2003")] TwoThousandThree = 2,
    [EnumMember(Value = "2015")] TwoThousandFifteen = 3,
    [EnumMember(Value = "future")] Future = 4,
}