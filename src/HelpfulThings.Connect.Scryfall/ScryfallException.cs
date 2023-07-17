namespace HelpfulThings.Connect.Scryfall;

public class ScryfallException : Exception
{
    public ScryfallException(string message, Exception innerException) : base(message, innerException){}
}