using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class MultiverseIdentifier : Identifier
{
    [JsonProperty("multiverse_id")] public int MultiverseId { get; set; }
}