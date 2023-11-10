using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Components
{
    [EnumMember(Value = "token")] Token = 0,
    [EnumMember(Value = "meld_part")] MeldPart = 1,
    [EnumMember(Value = "meld_result")] MeldResult = 2,
    [EnumMember(Value = "combo_piece")] ComboPiece = 3,
}