using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class CollectorNumberSetIdentifier(string collectorNumber = "", string set = "") : Identifier
{
    [JsonProperty("collector_number")] public readonly string CollectorNumber = collectorNumber;
    [JsonProperty("set")] public readonly string Set = set;
}