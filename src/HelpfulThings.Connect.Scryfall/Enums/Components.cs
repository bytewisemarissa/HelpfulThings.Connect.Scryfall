using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum Components
{
    [EnumMember(Value = "token")] Token = 1,
    [EnumMember(Value = "meld_part")] MeldPart = 2,
    [EnumMember(Value = "meld_result")] MeldResult = 3,
    [EnumMember(Value = "combo_piece")] ComboPiece = 4,
}