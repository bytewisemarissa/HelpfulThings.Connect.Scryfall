using System.Text.Json.Serialization;
using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class RelatedCard
{
    [JsonProperty("id")] public Guid Id { get; set; }
    [JsonProperty("component")] public Components Component { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("type_line")] public string TypeLine { get; set; }
    [JsonProperty("uri")] public Uri ScryfallApiUri { get; set; }

    public RelatedCard()
    {
        Name = string.Empty;
        TypeLine = string.Empty;
        ScryfallApiUri = new Uri(Constants.Localhost);
    }
}