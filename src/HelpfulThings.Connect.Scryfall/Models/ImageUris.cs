using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class ImageUris
{
    [JsonProperty("png")] public Uri Png { get; set; } = new(Constants.Localhost);
    [JsonProperty("border_crop")] public Uri BorderCrop { get; set; } = new(Constants.Localhost);
    [JsonProperty("art_crop")] public Uri ArtCrop { get; set; } = new(Constants.Localhost);
    [JsonProperty("large")] public Uri Large { get; set; } = new(Constants.Localhost);
    [JsonProperty("normal")] public Uri Normal { get; set; } = new(Constants.Localhost);
    [JsonProperty("small")] public Uri Small { get; set; } = new(Constants.Localhost);
}