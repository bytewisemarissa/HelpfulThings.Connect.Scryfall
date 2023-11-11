using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Frames
{
    [EnumMember(Value = "1993")] NineteenNinetyThree = 1,
    [EnumMember(Value = "1997")] NineteenNinetySeven = 2,
    [EnumMember(Value = "2003")] TwoThousandThree = 3,
    [EnumMember(Value = "2015")] TwoThousandFifteen = 4,
    [EnumMember(Value = "future")] Future = 5,
}