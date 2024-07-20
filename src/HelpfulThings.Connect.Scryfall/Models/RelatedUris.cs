using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class RelatedUris
{
    [JsonProperty("gatherer")] public Uri Gatherer { get; set; } = new(Constants.Localhost);
    [JsonProperty("tcgplayer_infinite_articles")] public Uri TcgPlayerInfiniteArticles { get; set; } = new(Constants.Localhost);
    [JsonProperty("tcgplayer_infinite_decks")] public Uri TcgPlayerInfiniteDecks { get; set; } = new(Constants.Localhost);
    [JsonProperty("edhrec")] public Uri Edhrec { get; set; } = new(Constants.Localhost);
}