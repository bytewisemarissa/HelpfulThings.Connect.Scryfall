using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum CardLayouts
{
    [EnumMember(Value = "normal")] Normal,
    [EnumMember(Value = "split")] Split,
    [EnumMember(Value = "flip")] Flip,
    [EnumMember(Value = "transform")] Transform,
    [EnumMember(Value = "modal_dfc")] ModalDualFacedCard,
    [EnumMember(Value = "meld")] Meld,
    [EnumMember(Value = "leveler")] Leveler,
    [EnumMember(Value = "class")] Class,
    [EnumMember(Value = "saga")] Saga,
    [EnumMember(Value = "adventure")] Adventure,
    [EnumMember(Value = "mutate")] Mutate,
    [EnumMember(Value = "prototype")] Prototype,
    [EnumMember(Value = "battle")] Battle,
    [EnumMember(Value = "planar")] Planar,
    [EnumMember(Value = "scheme")] Scheme,
    [EnumMember(Value = "vanguard")] Vanguard,
    [EnumMember(Value = "token")] Token,
    [EnumMember(Value = "double_faced_token")] DoubleFacedToken,
    [EnumMember(Value = "emblem")] Emblem,
    [EnumMember(Value = "augment")] Augment,
    [EnumMember(Value = "host")] Host,
    [EnumMember(Value = "art_series")] ArtSeries,
    [EnumMember(Value = "reversible_card")] ReversibleCard,
}