using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum SetTypes
{
    [EnumMember(Value = "core")] Core = 0,
    [EnumMember(Value = "expansion")] Expansion = 1,
    [EnumMember(Value = "masters")] Masters = 2,
    [EnumMember(Value = "alchemy")] Alchemy = 3,
    [EnumMember(Value = "masterpiece")] Masterpiece = 4,
    [EnumMember(Value = "arsenal")] Arsenal = 5,
    [EnumMember(Value = "from_the_vault")] FromTheVault = 6,
    [EnumMember(Value = "spellbook")] SpellBook = 7,
    [EnumMember(Value = "premium_deck")] PremiumDeck = 8,
    [EnumMember(Value = "duel_deck")] DuelDeck = 9,
    [EnumMember(Value = "draft_innovation")] DraftInnovation = 10,
    [EnumMember(Value = "treasure_chest")] TreasureChest = 11,
    [EnumMember(Value = "commander")] Commander = 12,
    [EnumMember(Value = "planechase")] PlaneChase = 13,
    [EnumMember(Value = "archenemy")] Archenemy = 14,
    [EnumMember(Value = "vanguard")] Vanguard = 15,
    [EnumMember(Value = "funny")] Funny = 16,
    [EnumMember(Value = "starter")] Starter = 17,
    [EnumMember(Value = "box")] Box = 18,
    [EnumMember(Value = "promo")] Promo = 19,
    [EnumMember(Value = "token")] Token = 20,
    [EnumMember(Value = "memorabilia")] Memorabilia = 21,
    [EnumMember(Value = "minigame")] MiniGame = 22
}