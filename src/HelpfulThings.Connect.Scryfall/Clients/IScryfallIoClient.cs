namespace HelpfulThings.Connect.Scryfall.Clients;

public interface IScryfallIoClient
{
    Task MakeNonMeteredRequest(
        Uri uri,
        IProgress<ScryfallIoClient.ScryfallIoProgress> progress, 
        Stream destination,
        CancellationToken cancellationToken = default
    );
}