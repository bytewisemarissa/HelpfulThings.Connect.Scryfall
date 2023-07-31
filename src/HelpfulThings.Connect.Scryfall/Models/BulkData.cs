using System.Net.Mime;
using System.Text.Json.Serialization;
using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class BulkData
{
    [JsonProperty("id")] public Guid Id { get; set; }
    [JsonProperty("type")] public BulkTypes Type { get; set; }
    [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
    [JsonProperty("uri")] public Uri Uri { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("size")] public long Size { get; set; }
    [JsonProperty("download_uri")] public Uri DownloadUri { get; set; }
    [JsonProperty("content_type")] public string ContentType { get; set; }
    [JsonProperty("content_encoding")] public string ContentEncoding { get; set; }

    public BulkData()
    {
        Uri = new Uri(Constants.Localhost);
        Name = string.Empty;
        Description = string.Empty;
        Size = 0;
        DownloadUri = new Uri(Constants.Localhost);
        ContentType = string.Empty;
        ContentEncoding = string.Empty;
    }
}