using System.Text.Json.Serialization;
using HelpfulThings.Connect.Scryfall.Identifiers;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.RequestResponse.Request;

public class CollectionRequest
{
    [JsonProperty("identifiers")] public List<Identifier> Identifiers { get; set; }

    public CollectionRequest()
    {
        Identifiers = new List<Identifier>();
    }
}