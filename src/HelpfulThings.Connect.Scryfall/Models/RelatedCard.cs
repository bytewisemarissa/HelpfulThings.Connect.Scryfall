using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class RelatedCard
{
    [JsonProperty("id")] public Guid Id { get; set; }
    [JsonProperty("component")] public Components Component { get; set; }
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;
    [JsonProperty("type_line")] public string TypeLine { get; set; } = string.Empty;
    [JsonProperty("uri")] public Uri ScryfallApiUri { get; set; } = new(Constants.Localhost);
}