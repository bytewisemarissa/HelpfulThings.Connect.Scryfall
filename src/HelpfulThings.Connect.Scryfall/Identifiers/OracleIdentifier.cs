using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class OracleIdentifier : Identifier
{
    [JsonProperty("oracle_id")] public Guid OracleId { get; set; }
}