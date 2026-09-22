using System.Net;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall;

public class ScryfallApiException : ScryfallException
{
    public HttpStatusCode StatusCode { get; }
    public ScryfallError? Error { get; }
    public string? ResponseBody { get; }

    public ScryfallApiException(HttpStatusCode statusCode, ScryfallError? error, string? responseBody)
        : base(BuildMessage(statusCode, error))
    {
        StatusCode = statusCode;
        Error = error;
        ResponseBody = responseBody;
    }

    private static string BuildMessage(HttpStatusCode statusCode, ScryfallError? error) =>
        error is not null
            ? $"Scryfall returned {(int)statusCode} ({error.Code}): {error.Details}"
            : $"Scryfall returned {(int)statusCode}.";
}
