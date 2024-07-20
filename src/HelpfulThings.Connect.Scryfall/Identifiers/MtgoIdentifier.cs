using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class MtgoIdentifier(long id = default) : Identifier
{
    [JsonProperty("mtgo_id")] public long MtgoId { get; set; } = id;
}