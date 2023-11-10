using System.Text.Json.Serialization;
using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class CardFace
{
    [JsonProperty("artist")] public string? ArtistName { get; set; }
    [JsonProperty("cmc")] public float? ConvertedManaCost { get; set; }
    [JsonProperty("color_indicator")] public Colors[] ColorIndicator { get; set; }
    [JsonProperty("colors")] public Colors[] Colors { get; set; }
    [JsonProperty("flavor_text")] public string? FlavorText { get; set; }
    [JsonProperty("illustration_id")] public Guid? IllustrationId { get; set; }
    [JsonProperty("image_uris")] public ImageUris ImageUris { get; set; }
    [JsonProperty("layout")] public string? Layout { get; set; }
    [JsonProperty("loyalty")] public string Loyalty { get; set; }
    [JsonProperty("mana_cost")] public string ManaCost { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("oracle_id")] public Guid? OracleId { get; set; }
    [JsonProperty("oracle_text")] public string? OracleText { get; set; }
    [JsonProperty("power")] public string? Power { get; set; }
    [JsonProperty("printed_name")] public string? PrintedName { get; set; }
    [JsonProperty("printed_text")] public string? PrintedText { get; set; }
    [JsonProperty("printed_type_line")] public string? PrintedTypeLine { get; set; }
    [JsonProperty("toughness")] public string? Toughness { get; set; }
    [JsonProperty("type_line")] public string? TypeLine { get; set; }
    [JsonProperty("watermark")] public string? Watermark { get; set; }

    public CardFace()
    {
        ColorIndicator = Array.Empty<Colors>();
        Colors = Array.Empty<Colors>();
        Loyalty = string.Empty;
        ManaCost = string.Empty;
        Name = string.Empty;
        ImageUris = new ImageUris();
    } 
}