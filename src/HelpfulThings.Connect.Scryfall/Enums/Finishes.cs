using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Finishes
{
    [EnumMember(Value = "foil")] Foil,
    [EnumMember(Value = "nonfoil")] NonFoil,
    [EnumMember(Value = "etched")] Etched
}