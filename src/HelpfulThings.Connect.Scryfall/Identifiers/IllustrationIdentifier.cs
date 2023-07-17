using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class IllustrationIdentifier : Identifier
{
    [JsonProperty("illustration_id")] public Guid IllustrationId { get; set; }
}