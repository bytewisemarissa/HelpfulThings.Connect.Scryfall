using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum CardLayouts
{
    [EnumMember(Value = "normal")] Normal = 1,
    [EnumMember(Value = "split")] Split = 2,
    [EnumMember(Value = "flip")] Flip = 3,
    [EnumMember(Value = "transform")] Transform = 4,
    [EnumMember(Value = "modal_dfc")] ModalDualFaceCard = 5,
    [EnumMember(Value = "meld")] Meld = 6,
    [EnumMember(Value = "leveler")] Leveler = 7,
    [EnumMember(Value = "class")] Class = 8,
    [EnumMember(Value = "saga")] Saga = 9,
    [EnumMember(Value = "adventure")] Adventure = 10,
    [EnumMember(Value = "mutate")] Mutate = 11,
    [EnumMember(Value = "prototype")] Prototype = 12,
    [EnumMember(Value = "battle")] Battle = 13,
    [EnumMember(Value = "planar")] Planar = 14,
    [EnumMember(Value = "scheme")] Scheme = 15,
    [EnumMember(Value = "vanguard")] Vanguard = 16,
    [EnumMember(Value = "token")] Token = 17,
    [EnumMember(Value = "double_faced_token")] DoubleFacedToken = 18,
    [EnumMember(Value = "emblem")] Emblem = 19,
    [EnumMember(Value = "augment")] Augment = 20,
    [EnumMember(Value = "host")] Host = 21,
    [EnumMember(Value = "art_series")] ArtSeries = 22,
    [EnumMember(Value = "reversible_card")] ReversibleCard = 23,
}