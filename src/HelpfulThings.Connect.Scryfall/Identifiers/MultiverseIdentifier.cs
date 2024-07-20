using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class MultiverseIdentifier(long id = default) : Identifier
{
    [JsonProperty("multiverse_id")] public long MultiverseId { get; set; } = id;
}