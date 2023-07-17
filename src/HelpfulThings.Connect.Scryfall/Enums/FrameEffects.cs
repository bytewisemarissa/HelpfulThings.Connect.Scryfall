using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum FrameEffects
{
    [EnumMember(Value = "legendary")] Legendary,
    [EnumMember(Value = "miracle")] Miracle,
    [EnumMember(Value = "nyxtouched")] NyxTouched,
    [EnumMember(Value = "draft")] Draft,
    [EnumMember(Value = "devoid")] Devoid,
    [EnumMember(Value = "tombstone")] Tombstone,
    [EnumMember(Value = "colorshifted")] ColorShifted,
    [EnumMember(Value = "inverted")] Inverted,
    [EnumMember(Value = "sunmoondfc")] SunMoon,
    [EnumMember(Value = "compasslanddfc")] CompassLand,
    [EnumMember(Value = "originpwdfc")] OriginPlaneswalker,
    [EnumMember(Value = "mooneldrazidfc")] MoonEldrazi,
    [EnumMember(Value = "waxingandwaningmoondfc")] WaxingWaning,
    [EnumMember(Value = "showcase")] Showcase,
    [EnumMember(Value = "extendedart")] ExtendedArt,
    [EnumMember(Value = "companion")] Companion,
    [EnumMember(Value = "etched")] Etched,
    [EnumMember(Value = "snow")] Snow,
    [EnumMember(Value = "lesson")] Lesson,
    [EnumMember(Value = "shatteredglass")] ShatteredGlass,
    [EnumMember(Value = "convertdfc")] MoreThanMeetsTheEye,
    [EnumMember(Value = "fandfc")] Fan,
    [EnumMember(Value = "upsidedowndfc")] UpsideDown
}