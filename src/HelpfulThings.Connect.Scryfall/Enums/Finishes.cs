using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Finishes
{
    [EnumMember(Value = "foil")] Foil = 0,
    [EnumMember(Value = "nonfoil")] NonFoil = 1,
    [EnumMember(Value = "etched")] Etched = 2
}