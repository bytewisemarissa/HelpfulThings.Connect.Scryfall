namespace HelpfulThings.Connect.Scryfall;

public class ScryfallException(string message, Exception innerException) : Exception(message, innerException);