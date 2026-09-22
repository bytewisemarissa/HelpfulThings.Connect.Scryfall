using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelpfulThings.Connect.Scryfall.Models;

public class Migration
{
    [JsonProperty("id")] public Guid Id { get; set; }
    [JsonProperty("uri")] public Uri Uri { get; set; } = new(Constants.Localhost);
    [JsonProperty("performed_at")] public DateOnly PerformedAt { get; set; }
    [JsonProperty("migration_strategy")] public string MigrationStrategy { get; set; } = string.Empty;
    [JsonProperty("old_scryfall_id")] public Guid OldScryfallId { get; set; }
    [JsonProperty("new_scryfall_id")] public Guid? NewScryfallId { get; set; }
    [JsonProperty("note")] public string? Note { get; set; }
    [JsonProperty("metadata")] public JObject? Metadata { get; set; }
}
