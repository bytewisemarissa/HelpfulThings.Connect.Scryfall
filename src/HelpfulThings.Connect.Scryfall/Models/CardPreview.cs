using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class CardPreview
{
    [JsonProperty("source")] public string? Source { get; set; }
    [JsonProperty("source_uri")] public Uri? SourceUri { get; set; }
    [JsonProperty("previewed_at")] public DateOnly? PreviewedAt { get; set; }
}
