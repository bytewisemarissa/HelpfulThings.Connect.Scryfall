using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class IllustrationIdentifier(Guid id = default) : Identifier
{
    [JsonProperty("illustration_id")] public Guid IllustrationId { get; set; } = id;

    public IllustrationIdentifier(string id) : this(new Guid(id))
    {
    }
}