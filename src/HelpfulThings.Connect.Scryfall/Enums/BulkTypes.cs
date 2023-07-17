using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum BulkTypes
{
    [EnumMember(Value = "oracle_cards")] OracleCards,
    [EnumMember(Value = "unique_artwork")] UniqueArtwork,
    [EnumMember(Value = "default_cards")] DefaultCards,
    [EnumMember(Value = "all_cards")] AllCards,
    [EnumMember(Value = "rulings")] Rulings
}