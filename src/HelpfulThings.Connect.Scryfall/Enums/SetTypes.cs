using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum SetTypes
{
    [EnumMember(Value = "core")] Core = 1,
    [EnumMember(Value = "expansion")] Expansion = 2,
    [EnumMember(Value = "masters")] Masters = 3,
    [EnumMember(Value = "alchemy")] Alchemy = 4,
    [EnumMember(Value = "masterpiece")] Masterpiece = 5,
    [EnumMember(Value = "arsenal")] Arsenal = 6,
    [EnumMember(Value = "from_the_vault")] FromTheVault = 7,
    [EnumMember(Value = "spellbook")] SpellBook = 8,
    [EnumMember(Value = "premium_deck")] PremiumDeck = 9,
    [EnumMember(Value = "duel_deck")] DuelDeck = 10,
    [EnumMember(Value = "draft_innovation")] DraftInnovation = 11,
    [EnumMember(Value = "treasure_chest")] TreasureChest = 12,
    [EnumMember(Value = "commander")] Commander = 13,
    [EnumMember(Value = "planechase")] PlaneChase = 14,
    [EnumMember(Value = "archenemy")] Archenemy = 15,
    [EnumMember(Value = "vanguard")] Vanguard = 16,
    [EnumMember(Value = "funny")] Funny = 17,
    [EnumMember(Value = "starter")] Starter = 18,
    [EnumMember(Value = "box")] Box = 19,
    [EnumMember(Value = "promo")] Promo = 20,
    [EnumMember(Value = "token")] Token = 21,
    [EnumMember(Value = "memorabilia")] Memorabilia = 22,
    [EnumMember(Value = "minigame")] MiniGame = 23
}