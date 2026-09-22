using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum ManifestOrder
{
    [EnumMember(Value = "released")] Released = 1,
    [EnumMember(Value = "imageupdated")] ImageUpdated = 2
}
