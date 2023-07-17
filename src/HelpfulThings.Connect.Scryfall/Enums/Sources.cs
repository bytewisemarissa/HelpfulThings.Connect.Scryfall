using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Sources
{
    [EnumMember(Value = "wotc")] WizardsOfTheCoast,
    [EnumMember(Value = "scryfall")] Scryfall
}