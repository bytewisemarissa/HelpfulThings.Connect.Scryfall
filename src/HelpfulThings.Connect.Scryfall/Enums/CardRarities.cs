using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum CardRarities
{
    [EnumMember(Value = "common")] Common = 1,
    [EnumMember(Value = "uncommon")] Uncommon = 2,
    [EnumMember(Value = "rare")] Rare = 3,
    [EnumMember(Value = "special")] Special = 4,
    [EnumMember(Value = "mythic")] Mythic = 5,
    [EnumMember(Value = "bonus")] Bonus = 6,
}