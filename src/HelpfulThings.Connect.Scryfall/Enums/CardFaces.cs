using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall.Enums;

public enum CardFaces
{
    [EnumMember(Value = "front")] Front,
    [EnumMember(Value = "back")] Back
}