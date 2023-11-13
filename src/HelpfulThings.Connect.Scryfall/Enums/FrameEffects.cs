using System.ComponentModel;
using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum FrameEffects
{
    [EnumMember(Value = "legendary")] [Description("Legendary")] Legendary = 1,
    [EnumMember(Value = "miracle")] [Description("Miracle")] Miracle = 2,
    [EnumMember(Value = "nyxtouched")] [Description("Nyx Touched")] NyxTouched = 3,
    [EnumMember(Value = "draft")] [Description("Draft")] Draft = 4,
    [EnumMember(Value = "devoid")] [Description("Devoid")] Devoid = 5,
    [EnumMember(Value = "tombstone")] [Description("Tombstone")] Tombstone = 6,
    [EnumMember(Value = "colorshifted")] [Description("Color Shifted")] ColorShifted = 7,
    [EnumMember(Value = "inverted")] [Description("Inverted")] Inverted = 8,
    [EnumMember(Value = "sunmoondfc")] [Description("Sun Moon")] SunMoon = 9,
    [EnumMember(Value = "compasslanddfc")] [Description("Compass Land")] CompassLand = 10,
    [EnumMember(Value = "originpwdfc")] [Description("Origin Planeswalker")] OriginPlaneswalker = 11,
    [EnumMember(Value = "mooneldrazidfc")] [Description("Moon Eldrazi")] MoonEldrazi = 12,
    [EnumMember(Value = "waxingandwaningmoondfc")] [Description("Waxing Waning")] WaxingWaning = 13,
    [EnumMember(Value = "showcase")] [Description("Showcase")] Showcase = 14,
    [EnumMember(Value = "extendedart")] [Description("Extended Art")] ExtendedArt = 15,
    [EnumMember(Value = "companion")] [Description("Companion")] Companion = 16,
    [EnumMember(Value = "etched")] [Description("Etched")] Etched = 17,
    [EnumMember(Value = "snow")] [Description("Snow")] Snow = 18,
    [EnumMember(Value = "lesson")] [Description("Lesson")] Lesson = 19,
    [EnumMember(Value = "shatteredglass")] [Description("Shattered Glass")] ShatteredGlass = 20,
    [EnumMember(Value = "convertdfc")] [Description("More Than Meets The Eye")] MoreThanMeetsTheEye = 21,
    [EnumMember(Value = "fandfc")] [Description("Fan")] Fan = 22,
    [EnumMember(Value = "upsidedowndfc")] [Description("Upside Down")] UpsideDown = 23,
    [EnumMember(Value = "fullart")] [Description("Full Art")] FullArt = 24,
    [EnumMember(Value = "vehicle")] [Description("Vehicle")] Vehicle = 25,
    [EnumMember(Value = "textless")] [Description("Textless")] Textless = 26,
}