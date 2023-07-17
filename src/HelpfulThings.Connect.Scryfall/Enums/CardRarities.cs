using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum CardRarities
{
    [EnumMember(Value = "common")] Common,
    [EnumMember(Value = "uncommon")] Uncommon,
    [EnumMember(Value = "rare")] Rare,
    [EnumMember(Value = "special")] Special,
    [EnumMember(Value = "mythic")] Mythic,
    [EnumMember(Value = "bonus")] Bonus,
}