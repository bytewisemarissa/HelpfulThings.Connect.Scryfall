using System.Text.Json.Serialization;
using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class CardSymbol
{
    [JsonProperty("symbol")] public string Symbol { get; set; }
    [JsonProperty("loose_variant")] public string? LooseVariant { get; set; }
    [JsonProperty("english")] public string English { get; set; }
    [JsonProperty("transposable")] public bool Transposable { get; set; }
    [JsonProperty("represents_mana")] public bool RepresentsMana { get; set; }
    [JsonProperty("mana_value")] public float? ManaValue { get; set; }
    [JsonProperty("appears_in_mana_costs")] public bool AppearsInManaCosts { get; set; }
    [JsonProperty("funny")] public bool Funny { get; set; }
    [JsonProperty("colors")] public Colors[] Colors { get; set; }
    [JsonProperty("gatherer_alternates")] public string[]? GathererAlternates { get; set; }
    [JsonProperty("svg_uri")] public Uri? SvgUri { get; set; }
    [JsonProperty("cmc")] public float? ConvertedManaCost { get; set; }

    public CardSymbol()
    {
        Symbol = string.Empty;
        English = string.Empty;
        Colors = Array.Empty<Colors>();
    }
}