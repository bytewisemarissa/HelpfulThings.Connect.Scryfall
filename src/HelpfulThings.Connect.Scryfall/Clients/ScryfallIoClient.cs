using System.Globalization;

namespace HelpfulThings.Connect.Scryfall.Clients;

public class ScryfallIoClient : IScryfallIoClient
{
    private static readonly HttpClient IoClient;
    private static bool _fireAlert = true;

    static ScryfallIoClient()
    {
        IoClient = new HttpClient();
    }
    
    public class ScryfallIoProgress
    {
        public long DownloadedBytes { get; set; }
        public long TotalBytes { get; set; }
        public string Message { get; set; }
        private string Percentage
        {
            get
            {
                var value = ((double)DownloadedBytes / TotalBytes) * 100f;
                value = Math.Round(value, 2);
                return $"{value.ToString(CultureInfo.InvariantCulture)}%";
            }
        }

        public ScryfallIoProgress()
        {
            Message = string.Empty;
        }
    }

    public async Task MakeNonMeteredRequest(
        Uri uri,
        IProgress<ScryfallIoProgress> progress, 
        Stream destination,
        CancellationToken cancellationToken = default
    )
    {
        if (!uri.Host.Contains("scryfall.io"))
        {
            throw new ArgumentException("Sorry, you can not make non metered requests to a non scryfall.io domain.");
        }
        
        if (destination == null)
            throw new ArgumentNullException(nameof(destination));
        if (!destination.CanWrite)
            throw new ArgumentException("Has to be writable", nameof(destination));
        
        using (var response = await IoClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead))
        {
            using (var download = await response.Content.ReadAsStreamAsync(cancellationToken))
            {
                var buffer = new byte[524288];
                long totalBytesRead = 0;
                int bytesRead;
                while ((bytesRead =
                           await download.ReadAsync(
                                   buffer,
                                   0,
                                   buffer.Length,
                                   cancellationToken)
                               .ConfigureAwait(false)) != 0)
                {

                    if (_fireAlert)
                    {
                        await destination.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
                        totalBytesRead += bytesRead;
                        progress?.Report(new ScryfallIoProgress()
                        {
                            DownloadedBytes = totalBytesRead,
                            Message = "Downloading"
                        });

                        Task.Run(async () =>
                        {
                            await Task.Delay(1000);
                            _fireAlert = true;
                        });

                        _fireAlert = false;
                    }
                }
            }
        }
    }
}