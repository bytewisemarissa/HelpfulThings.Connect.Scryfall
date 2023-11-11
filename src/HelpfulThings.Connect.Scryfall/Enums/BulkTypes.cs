using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum BulkTypes
{
    [EnumMember(Value = "oracle_cards")] OracleCards = 1,
    [EnumMember(Value = "unique_artwork")] UniqueArtwork = 2,
    [EnumMember(Value = "default_cards")] DefaultCards = 3,
    [EnumMember(Value = "all_cards")] AllCards = 4,
    [EnumMember(Value = "rulings")] Rulings = 5
}