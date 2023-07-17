using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.RequestResponse.Response;

public class ScryfallCatalog
{
    [JsonProperty("uri")] public Uri Uri { get; set; }
    [JsonProperty("total_values")] public int TotalValues { get; set; }
    [JsonProperty("data")] public List<string> Data { get; set; }

    public ScryfallCatalog()
    {
        Uri = new Uri(Constants.Localhost);
        Data = new List<string>();
    }
}