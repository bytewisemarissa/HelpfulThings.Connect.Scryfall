using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum CatalogTypes
{
    [EnumMember(Value = "card-names")] CardNames = 1,
    [EnumMember(Value = "artist-names")] ArtistNames = 2,
    [EnumMember(Value = "word-bank")] WordBank = 3,
    [EnumMember(Value = "creature-types")] CreatureTypes = 4,
    [EnumMember(Value = "planeswalker-types")] PlaneswalkerTypes = 5,
    [EnumMember(Value = "land-types")] LandTypes = 6,
    [EnumMember(Value = "artifact-types")] ArtifactTypes = 7,
    [EnumMember(Value = "enchantment-types")] EnchantmentTypes = 8,
    [EnumMember(Value = "spell-types")] SpellTypes = 9,
    [EnumMember(Value = "powers")] Powers = 10,
    [EnumMember(Value = "toughnesses")] Toughnesses = 11,
    [EnumMember(Value = "loyalties")] Loyalties = 12,
    [EnumMember(Value = "watermarks")] Watermarks = 13,
    [EnumMember(Value = "keyword-abilities")] KeywordAbilities = 14,
    [EnumMember(Value = "keyword-actions")] KeywordActions = 15,
    [EnumMember(Value = "ability-words")] AbilityWords = 16
}