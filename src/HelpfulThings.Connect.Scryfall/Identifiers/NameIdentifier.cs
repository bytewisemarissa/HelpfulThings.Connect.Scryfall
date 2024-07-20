using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class NameIdentifier(string name  = "") : Identifier
{
    [JsonProperty("name")] public string Name { get; set; } = name;
}