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
    [JsonProperty("jsonl_download_uri")] public Uri JsonlDownloadUri { get; set; } = new(Constants.Localhost);
    [JsonProperty("compressed_size")] public long CompressedSize { get; set; }
}
