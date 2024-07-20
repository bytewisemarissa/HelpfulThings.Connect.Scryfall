using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class OracleIdentifier(Guid oracleId = default) : Identifier
{
    [JsonProperty("oracle_id")] public Guid OracleId { get; set; } = oracleId;

    public OracleIdentifier(string oracleId) : this(new Guid(oracleId))
    {
    }
}