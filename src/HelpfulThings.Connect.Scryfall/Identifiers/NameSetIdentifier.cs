using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class NameSetIdentifier : Identifier
{
    [JsonProperty("name")] public readonly string Name;
    [JsonProperty("set")] public readonly string Set;

    public NameSetIdentifier(string name, string set)
    {
        Name = name;
        Set = set;
    }
}