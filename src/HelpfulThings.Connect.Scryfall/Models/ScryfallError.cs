using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class ScryfallError
{
    [JsonProperty("object")] public string Object { get; set; } = string.Empty;
    [JsonProperty("status")] public int Status { get; set; }
    [JsonProperty("code")] public string Code { get; set; } = string.Empty;
    [JsonProperty("details")] public string Details { get; set; } = string.Empty;
    [JsonProperty("type")] public string? Type { get; set; }
    [JsonProperty("warnings")] public string[]? Warnings { get; set; }
}
