using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Components
{
    [EnumMember(Value = "token")] Token,
    [EnumMember(Value = "meld_part")] MeldPart,
    [EnumMember(Value = "meld_result")] MeldResult,
    [EnumMember(Value = "combo_piece")] ComboPiece,
}