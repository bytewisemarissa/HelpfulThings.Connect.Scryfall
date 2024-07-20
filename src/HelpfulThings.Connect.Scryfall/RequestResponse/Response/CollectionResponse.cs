using HelpfulThings.Connect.Scryfall.Converters;
using HelpfulThings.Connect.Scryfall.Identifiers;
using HelpfulThings.Connect.Scryfall.Models;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.RequestResponse.Response;

public class CollectionResponse
{
    [JsonProperty("not_found")]
    [JsonConverter(typeof(IdentifierConverter))]
    public List<Identifier> NotFound { get; set; } = [];

    [JsonProperty("data")] public List<Card> Data { get; set; } = [];
}