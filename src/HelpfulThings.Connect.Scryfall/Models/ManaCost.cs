using System.Text.Json.Serialization;
using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class ManaCost
{
    [JsonProperty("cost")] public string Cost { get; set; }
    [JsonProperty("cmc")] public float ConvertManaCost { get; set; }
    [JsonProperty("colors")] public Colors[] Colors { get; set; }
    [JsonProperty("colorless")] public bool Colorless { get; set; }
    [JsonProperty("monocolored")] public bool MonoColor { get; set; }
    [JsonProperty("multicolored")] public bool MultiColored { get; set; }

    public ManaCost()
    {
        Cost = string.Empty;
        Colors = Array.Empty<Colors>();
    }
}