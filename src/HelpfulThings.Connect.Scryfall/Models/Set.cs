using System.Text.Json.Serialization;
using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HelpfulThings.Connect.Scryfall.Models;

public class Set
{
    [JsonProperty("id")] public Guid ScryfallId { get; set; }
    [JsonProperty("code")] public string Code { get; set; }
    [JsonProperty("mtgo_code")] public string? MtgoCode { get; set; }
    [JsonProperty("arena_code")] public string? ArenaCode { get; set; }
    [JsonProperty("tcgplayer_id")] public int? TcgPlayerId { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("set_type")] public SetTypes SetType { get; set; }
    [JsonProperty("released_at")] public DateTime? ReleasedAt { get; set; }
    [JsonProperty("block_code")] public string? BlockCode { get; set; }
    [JsonProperty("block")] public string? Block { get; set; }
    [JsonProperty("parent_set_code")] public string? ParentSetCode { get; set; }
    [JsonProperty("card_count")] public int CardCount { get; set; }
    [JsonProperty("printed_size")] public int? PrintedSize { get; set; }
    [JsonProperty("digital")] public bool Digital { get; set; }
    [JsonProperty("foil_only")] public bool FoilOnly { get; set; }
    [JsonProperty("nonfoil_only")] public bool NonFoilOnly { get; set; }
    [JsonProperty("scryfall_uri")] public Uri ScryfallUri { get; set; }
    [JsonProperty("uri")] public Uri SetApiLink { get; set; }
    [JsonProperty("icon_svg_uri")] public Uri IconSvgUri { get; set; }
    [JsonProperty("search_uri")] public Uri SearchUri { get; set; }

    public Set()
    {
        Code = string.Empty;
        Name = string.Empty;
        ScryfallUri = new Uri(Constants.Localhost);
        SetApiLink = new Uri(Constants.Localhost);
        IconSvgUri = new Uri(Constants.Localhost);
        SearchUri = new Uri(Constants.Localhost);
    }
}