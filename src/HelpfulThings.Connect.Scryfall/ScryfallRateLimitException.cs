using System.Net;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall;

public class ScryfallRateLimitException : ScryfallApiException
{
    public TimeSpan? RetryAfter { get; }

    public ScryfallRateLimitException(ScryfallError? error, string? responseBody, TimeSpan? retryAfter)
        : base(HttpStatusCode.TooManyRequests, error, responseBody)
    {
        RetryAfter = retryAfter;
    }
}
