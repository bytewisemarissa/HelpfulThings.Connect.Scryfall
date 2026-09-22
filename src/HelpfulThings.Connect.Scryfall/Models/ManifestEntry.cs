using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class ManifestEntry
{
    [JsonProperty("id")] public Guid Id { get; set; }
    [JsonProperty("oracle_id")] public Guid? OracleId { get; set; }
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;
    [JsonProperty("set_code")] public string SetCode { get; set; } = string.Empty;
    [JsonProperty("collector_number")] public string CollectorNumber { get; set; } = string.Empty;
    [JsonProperty("lang")] public string Language { get; set; } = string.Empty;
    [JsonProperty("created_at")] public DateTime? CreatedAt { get; set; }
    [JsonProperty("data_updated_at")] public DateTime? DataUpdatedAt { get; set; }
    [JsonProperty("image_updated_at")] public DateTime? ImageUpdatedAt { get; set; }
}
