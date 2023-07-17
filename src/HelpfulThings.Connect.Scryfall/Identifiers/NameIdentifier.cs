using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class NameIdentifier : Identifier
{
    [JsonProperty("name")] public string Name { get; set; }

    public NameIdentifier()
    {
        Name = string.Empty;
    }
}