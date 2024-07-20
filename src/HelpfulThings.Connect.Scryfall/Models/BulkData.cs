using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class BulkData
{
    [JsonProperty("id")] public Guid Id { get; set; }
    [JsonProperty("type")] public BulkTypes Type { get; set; }
    [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
    [JsonProperty("uri")] public Uri Uri { get; set; } = new(Constants.Localhost);
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;
    [JsonProperty("description")] public string Description { get; set; } = string.Empty;
    [JsonProperty("size")] public long Size { get; set; }
    [JsonProperty("download_uri")] public Uri DownloadUri { get; set; } = new(Constants.Localhost);
    [JsonProperty("content_type")] public string ContentType { get; set; } = string.Empty;
    [JsonProperty("content_encoding")] public string ContentEncoding { get; set; } = string.Empty;
}