using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class PurchaseUris
{
    [JsonProperty("tcgplayer")] public Uri TcgPlayer { get; set; } = new(Constants.Localhost);
    [JsonProperty("cardmarket")] public Uri CardMarket { get; set; } = new(Constants.Localhost);
    [JsonProperty("cardhoarder")] public Uri CardHoarder { get; set; } = new(Constants.Localhost);
}
