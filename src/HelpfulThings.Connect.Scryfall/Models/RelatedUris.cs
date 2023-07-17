using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class RelatedUris
{
    [JsonProperty("gatherer")] public Uri Gatherer { get; set; }
    [JsonProperty("tcgplayer_infinite_articles")] public Uri TcgPlayerInfiniteArticles { get; set; }
    [JsonProperty("tcgplayer_infinite_decks")] public Uri TcgPlayerInfiniteDecks { get; set; }
    [JsonProperty("edhrec")] public Uri Edhrec { get; set; }

    public RelatedUris()
    {
        Gatherer = new Uri(Constants.Localhost);
        TcgPlayerInfiniteArticles = new Uri(Constants.Localhost);
        TcgPlayerInfiniteDecks = new Uri(Constants.Localhost);
        Edhrec = new Uri(Constants.Localhost);
    }
}