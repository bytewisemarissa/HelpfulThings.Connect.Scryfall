using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum CardRarities
{
    [EnumMember(Value = "common")] Common = 0,
    [EnumMember(Value = "uncommon")] Uncommon = 1,
    [EnumMember(Value = "rare")] Rare = 2,
    [EnumMember(Value = "special")] Special = 3,
    [EnumMember(Value = "mythic")] Mythic = 4,
    [EnumMember(Value = "bonus")] Bonus = 5,
}