using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.RequestResponse.Response;

public class ScryfallList<T>
{
    [System.Text.Json.Serialization.JsonIgnore] public readonly Type HostedType = typeof(T);
    [JsonProperty("next_page")] public Uri? NextPage { get; set; }
    [JsonProperty("total_cards")] public int? TotalCards { get; set; }
    [JsonProperty("warnings")] public string[]? Warnings { get; set; }
    [JsonProperty("has_more")] public bool HasMore { get; set; }
    [JsonProperty("data")] public T[] Data { get; set; } = [];
}