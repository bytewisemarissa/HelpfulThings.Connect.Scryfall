using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Finishes
{
    [EnumMember(Value = "foil")] Foil = 1,
    [EnumMember(Value = "nonfoil")] NonFoil = 2,
    [EnumMember(Value = "etched")] Etched = 3
}