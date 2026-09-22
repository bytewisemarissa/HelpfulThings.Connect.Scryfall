using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.RequestResponse.Response;

public class ScryfallList<T>
{
    [JsonProperty("next_page")] public Uri? NextPage { get; set; }
    [JsonProperty("total_cards")] public int? TotalCards { get; set; }
    [JsonProperty("warnings")] public string[]? Warnings { get; set; }
    [JsonProperty("has_more")] public bool HasMore { get; set; }
    [JsonProperty("data")] public T[] Data { get; set; } = [];
}