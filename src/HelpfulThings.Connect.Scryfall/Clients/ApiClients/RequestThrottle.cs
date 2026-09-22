using System.Diagnostics;

namespace HelpfulThings.Connect.Scryfall.Clients.ApiClients;

/// <summary>
/// Enforces the documented per-endpoint minimum request interval, plus Scryfall's
/// global 10 requests/second cap (every request also passes through the
/// <see cref="RateLimitCategory.Default"/> gate).
/// </summary>
internal static class RequestThrottle
{
    private static readonly IReadOnlyDictionary<RateLimitCategory, CategoryGate> Gates =
        new Dictionary<RateLimitCategory, CategoryGate>
        {
            [RateLimitCategory.Default] = new(TimeSpan.FromMilliseconds(100)),
            [RateLimitCategory.CardSearch] = new(TimeSpan.FromMilliseconds(500)),
            [RateLimitCategory.Manifest] = new(TimeSpan.FromMilliseconds(6000))
        };

    public static Task<T> ThrottleAsync<T>(
        RateLimitCategory category,
        Func<Task<T>> action,
        CancellationToken cancellationToken) =>
        Gates[category].RunAsync(() =>
            category == RateLimitCategory.Default
                ? action()
                : Gates[RateLimitCategory.Default].RunAsync(action, cancellationToken),
            cancellationToken);

    private sealed class CategoryGate(TimeSpan interval)
    {
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private long _lastSentTimestamp = -1;

        public async Task<T> RunAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                if (_lastSentTimestamp >= 0)
                {
                    var remaining = interval - Stopwatch.GetElapsedTime(_lastSentTimestamp);
                    if (remaining > TimeSpan.Zero)
                    {
                        await Task.Delay(remaining, cancellationToken);
                    }
                }

                var result = await action();
                _lastSentTimestamp = Stopwatch.GetTimestamp();
                return result;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
