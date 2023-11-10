using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum CardLayouts
{
    [EnumMember(Value = "normal")] Normal = 0,
    [EnumMember(Value = "split")] Split = 1,
    [EnumMember(Value = "flip")] Flip = 2,
    [EnumMember(Value = "transform")] Transform = 3,
    [EnumMember(Value = "modal_dfc")] ModalDualFacedCard = 4,
    [EnumMember(Value = "meld")] Meld = 5,
    [EnumMember(Value = "leveler")] Leveler = 6,
    [EnumMember(Value = "class")] Class = 7,
    [EnumMember(Value = "saga")] Saga = 8,
    [EnumMember(Value = "adventure")] Adventure = 9,
    [EnumMember(Value = "mutate")] Mutate = 10,
    [EnumMember(Value = "prototype")] Prototype = 11,
    [EnumMember(Value = "battle")] Battle = 12,
    [EnumMember(Value = "planar")] Planar = 13,
    [EnumMember(Value = "scheme")] Scheme = 14,
    [EnumMember(Value = "vanguard")] Vanguard = 15,
    [EnumMember(Value = "token")] Token = 16,
    [EnumMember(Value = "double_faced_token")] DoubleFacedToken = 17,
    [EnumMember(Value = "emblem")] Emblem = 18,
    [EnumMember(Value = "augment")] Augment = 19,
    [EnumMember(Value = "host")] Host = 20,
    [EnumMember(Value = "art_series")] ArtSeries = 21,
    [EnumMember(Value = "reversible_card")] ReversibleCard = 22,
}