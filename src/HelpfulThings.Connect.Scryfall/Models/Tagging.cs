using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class Tagging
{
    [JsonProperty("illustration_id")] public Guid? IllustrationId { get; set; }
    [JsonProperty("oracle_id")] public Guid? OracleId { get; set; }
    [JsonProperty("weight")] public int Weight { get; set; }
    [JsonProperty("annotation")] public string? Annotation { get; set; }
}
