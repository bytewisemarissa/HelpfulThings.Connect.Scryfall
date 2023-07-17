using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Frames
{
    [EnumMember(Value = "1993")] NineteenNinetyThree,
    [EnumMember(Value = "1997")] NineteenNinetySeven,
    [EnumMember(Value = "2003")] TwoThousandThree,
    [EnumMember(Value = "2015")] TwoThousandFifteen,
    [EnumMember(Value = "future")] Future,
}