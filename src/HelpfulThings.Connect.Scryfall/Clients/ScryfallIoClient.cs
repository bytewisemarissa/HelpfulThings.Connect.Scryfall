using System.Buffers;

namespace HelpfulThings.Connect.Scryfall.Clients;

public class ScryfallIoClient : IScryfallIoClient
{
    private const int BufferSize = 81920;

    private static readonly HttpClient IoClient;

    static ScryfallIoClient()
    {
        IoClient = new HttpClient();
    }

    public class ScryfallIoProgress
    {
        public long DownloadedBytes { get; set; }
        public long TotalBytes { get; set; }
        public string Message { get; set; } = string.Empty;

        public double? Percentage =>
            TotalBytes == 0 ? null : Math.Round((double)DownloadedBytes / TotalBytes * 100, 2);
    }

    public async Task MakeNonMeteredRequest(
        Uri uri,
        IProgress<ScryfallIoProgress>? progress,
        Stream destination,
        CancellationToken cancellationToken = default
    )
    {
        if (uri.Host != "scryfall.io" && !uri.Host.EndsWith(".scryfall.io", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Sorry, you can not make non metered requests to a non scryfall.io domain.");
        }

        ArgumentNullException.ThrowIfNull(destination);
        if (!destination.CanWrite)
            throw new ArgumentException("Has to be writable", nameof(destination));

        using var response = await IoClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();

        var totalBytes = response.Content.Headers.ContentLength ?? 0;

        await using var download = await response.Content.ReadAsStreamAsync(cancellationToken);

        var buffer = ArrayPool<byte>.Shared.Rent(BufferSize);
        try
        {
            long totalBytesRead = 0;
            int bytesRead;
            while ((bytesRead = await download.ReadAsync(buffer.AsMemory(0, BufferSize), cancellationToken)
                       .ConfigureAwait(false)) != 0)
            {
                await destination.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken).ConfigureAwait(false);
                totalBytesRead += bytesRead;
                progress?.Report(new ScryfallIoProgress
                {
                    DownloadedBytes = totalBytesRead,
                    TotalBytes = totalBytes,
                    Message = "Downloading"
                });
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
