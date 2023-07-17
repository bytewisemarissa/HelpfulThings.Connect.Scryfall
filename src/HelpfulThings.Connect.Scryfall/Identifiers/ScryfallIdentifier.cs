using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class ScryfallIdentifier : Identifier
{
    [JsonProperty("id")] public Guid ScryfallId { get; set; }
}