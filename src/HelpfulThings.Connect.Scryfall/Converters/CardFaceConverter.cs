using System.Text.Json.Serialization;
using HelpfulThings.Connect.Scryfall.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelpfulThings.Connect.Scryfall.Converters;

public class CardFaceConverter : Newtonsoft.Json.JsonConverter<CardFace>
{
    public override void WriteJson(JsonWriter writer, CardFace? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override CardFace? ReadJson(JsonReader reader, Type objectType, CardFace? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var semiParsed = JObject.Load(reader);
        var imageUrisToken = semiParsed["image_uris"];
        if (imageUrisToken is null)
        {
            throw new NullReferenceException("No Image Uris value found.");
        }
        switch(imageUrisToken.Type)
        {
            case JTokenType.Null:
            case JTokenType.Array:
                return semiParsed.ToObject<CardFace>();
        }

        var intermediate = semiParsed.ToObject<CardFaceWithSingleImageUri>();

        if (intermediate is null)
        {
            throw new NullReferenceException("Intermediate object failed to parse.");
        }

        return new CardFace()
        {
            ArtistName = intermediate.ArtistName,
            ConvertedManaCost = intermediate.ConvertedManaCost,
            ColorIndicator = intermediate.ColorIndicator,
            Colors = intermediate.Colors,
            FlavorText = intermediate.FlavorText,
            IllustrationId = intermediate.IllustrationId,
            ImageUris = new[] { intermediate.ImageUris },
            Layout = intermediate.Layout,
            Loyalty = intermediate.Loyalty,
            ManaCost = intermediate.ManaCost,
            Name = intermediate.Name,
            OracleId = intermediate.OracleId,
            OracleText = intermediate.OracleText,
            Power = intermediate.Power,
            PrintedName = intermediate.PrintedName,
            PrintedText = intermediate.PrintedText,
            PrintedTypeLine = intermediate.PrintedTypeLine,
            Toughness = intermediate.Toughness,
            TypeLine = intermediate.TypeLine,
            Watermark = intermediate.Watermark
        };
    }
    
    private class CardFaceWithSingleImageUri : CardFace
    {
        [JsonPropertyName("image_uris")] public new Uri ImageUris { get; set; }

        public CardFaceWithSingleImageUri()
        {
            ImageUris = new Uri(string.Empty);
        }
    }
}