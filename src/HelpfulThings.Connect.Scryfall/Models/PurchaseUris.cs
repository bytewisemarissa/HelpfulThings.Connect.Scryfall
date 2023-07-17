namespace HelpfulThings.Connect.Scryfall.Models;

public class PurchaseUris
{
    public Uri TcgPlayer { get; set; }
    public Uri CardMarket { get; set; }
    public Uri CardHoarder { get; set; }

    public PurchaseUris()
    {
        TcgPlayer = new Uri(Constants.Localhost);
        CardMarket = new Uri(Constants.Localhost);
        CardHoarder = new Uri(Constants.Localhost);
    }
}