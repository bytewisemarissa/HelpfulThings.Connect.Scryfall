using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum ImageVersions
{
     [EnumMember(Value = "small")] Small = 1,
     [EnumMember(Value = "normal")] Normal = 2,
     [EnumMember(Value = "large")] Large = 3,
     [EnumMember(Value = "png")] Png = 4,
     [EnumMember(Value = "art_crop")] ArtCrop = 5,
     [EnumMember(Value = "border_crop")] BorderCrop = 6
}