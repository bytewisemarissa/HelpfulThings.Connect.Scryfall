using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class NameSetIdentifier(string name = "", string set = "") : Identifier
{
    [JsonProperty("name")] public string Name { get; set; } = name;
    [JsonProperty("set")] public string Set { get; set; } = set;
}