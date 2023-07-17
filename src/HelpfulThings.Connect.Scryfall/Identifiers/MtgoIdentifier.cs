using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class MtgoIdentifier : Identifier
{
    [JsonProperty("mtgo_id")] public int MtgoId { get; set; }
}