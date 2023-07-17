using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class CollectorNumberSetIdentifier : Identifier
{
    [JsonProperty("collector_number")] public readonly string CollectorNumber;
    [JsonProperty("set")] public readonly string Set;

    public CollectorNumberSetIdentifier(string collectorNumber, string set)
    {
        CollectorNumber = collectorNumber;
        Set = set;
    }
}