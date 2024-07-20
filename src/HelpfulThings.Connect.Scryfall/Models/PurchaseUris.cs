namespace HelpfulThings.Connect.Scryfall.Models;

public class PurchaseUris
{
    public Uri TcgPlayer { get; set; } = new(Constants.Localhost);
    public Uri CardMarket { get; set; } = new(Constants.Localhost);
    public Uri CardHoarder { get; set; } = new(Constants.Localhost);
}