using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum SetTypes
{
    [EnumMember(Value = "core")] Core,
    [EnumMember(Value = "expansion")] Expansion,
    [EnumMember(Value = "masters")] Masters,
    [EnumMember(Value = "alchemy")] Alchemy,
    [EnumMember(Value = "masterpiece")] Masterpiece,
    [EnumMember(Value = "arsenal")] Arsenal,
    [EnumMember(Value = "from_the_vault")] FromTheVault,
    [EnumMember(Value = "spellbook")] SpellBook,
    [EnumMember(Value = "premium_deck")] PremiumDeck,
    [EnumMember(Value = "duel_deck")] DuelDeck,
    [EnumMember(Value = "draft_innovation")] DraftInnovation,
    [EnumMember(Value = "treasure_chest")] TreasureChest,
    [EnumMember(Value = "commander")] Commander,
    [EnumMember(Value = "planechase")] PlaneChase,
    [EnumMember(Value = "archenemy")] Archenemy,
    [EnumMember(Value = "vanguard")] Vanguard,
    [EnumMember(Value = "funny")] Funny,
    [EnumMember(Value = "starter")] Starter,
    [EnumMember(Value = "box")] Box,
    [EnumMember(Value = "promo")] Promo,
    [EnumMember(Value = "token")] Token,
    [EnumMember(Value = "memorabilia")] Memorabilia,
    [EnumMember(Value = "minigame")] MiniGame
}