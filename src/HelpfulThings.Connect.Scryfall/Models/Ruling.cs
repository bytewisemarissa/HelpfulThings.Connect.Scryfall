using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class Ruling
{
    [JsonProperty("oracle_id")] public Guid OracleId { get; set; }
    [JsonProperty("source")] public Sources Source { get; set; }
    [JsonProperty("published_at")] public DateOnly PublishedAt { get; set; }
    [JsonProperty("comment")] public string Comment { get; set; } = string.Empty;
}