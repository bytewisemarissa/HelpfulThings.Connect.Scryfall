using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Identifiers;

public class ScryfallIdentifier(Guid scryfallId = default) : Identifier
{
    [JsonProperty("id")] public Guid ScryfallId { get; set; } = scryfallId;
    
    public ScryfallIdentifier(string scryfallId) : this(new Guid(scryfallId))
    {
    }
}