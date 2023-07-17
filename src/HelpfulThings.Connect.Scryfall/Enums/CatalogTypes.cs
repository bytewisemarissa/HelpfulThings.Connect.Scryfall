using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum CatalogTypes
{
    [EnumMember(Value = "card-names")] CardNames,
    [EnumMember(Value = "artist-names")] ArtistNames,
    [EnumMember(Value = "word-bank")] WordBank,
    [EnumMember(Value = "creature-types")] CreatureTypes,
    [EnumMember(Value = "planeswalker-types")] PlaneswalkerTypes,
    [EnumMember(Value = "land-types")] LandTypes,
    [EnumMember(Value = "artifact-types")] ArtifactTypes,
    [EnumMember(Value = "enchantment-types")] EnchantmentTypes,
    [EnumMember(Value = "spell-types")] SpellTypes,
    [EnumMember(Value = "powers")] Powers,
    [EnumMember(Value = "toughnesses")] Toughnesses,
    [EnumMember(Value = "loyalties")] Loyalties,
    [EnumMember(Value = "watermarks")] Watermarks,
    [EnumMember(Value = "keyword-abilities")] KeywordAbilities,
    [EnumMember(Value = "keyword-actions")] KeywordActions,
    [EnumMember(Value = "ability-words")] AbilityWords
}