using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class ImageUris
{
    [JsonProperty("png")] public Uri Png { get; set; }
    [JsonProperty("border_crop")] public Uri BorderCrop { get; set; }
    [JsonProperty("art_crop")] public Uri ArtCrop { get; set; }
    [JsonProperty("large")] public Uri Large { get; set; }
    [JsonProperty("normal")] public Uri Normal { get; set; }
    [JsonProperty("small")] public Uri Small { get; set; }

    public ImageUris()
    {
        Png = new Uri(Constants.Localhost);
        BorderCrop = new Uri(Constants.Localhost);
        ArtCrop = new Uri(Constants.Localhost);
        Large = new Uri(Constants.Localhost);
        Normal = new Uri(Constants.Localhost);
        Small = new Uri(Constants.Localhost);
    }
}