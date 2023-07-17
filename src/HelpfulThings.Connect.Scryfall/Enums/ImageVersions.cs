using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum ImageVersions
{
     [EnumMember(Value = "small")] Small,
     [EnumMember(Value = "normal")] Normal,
     [EnumMember(Value = "large")] Large,
     [EnumMember(Value = "png")] Png,
     [EnumMember(Value = "art_crop")] ArtCrop,
     [EnumMember(Value = "border_crop")] BorderCrop
}