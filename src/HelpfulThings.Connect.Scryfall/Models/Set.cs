using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class Set
{
    [JsonProperty("id")] public Guid ScryfallId { get; set; }
    [JsonProperty("code")] public string Code { get; set; } = string.Empty;
    [JsonProperty("mtgo_code")] public string? MtgoCode { get; set; }
    [JsonProperty("arena_code")] public string? ArenaCode { get; set; }
    [JsonProperty("tcgplayer_id")] public int? TcgPlayerId { get; set; }
    [JsonProperty("name")] public string Name { get; set; } = string.Empty;
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
    [JsonProperty("scryfall_uri")] public Uri ScryfallUri { get; set; } = new(Constants.Localhost);
    [JsonProperty("uri")] public Uri SetApiLink { get; set; } = new(Constants.Localhost);
    [JsonProperty("icon_svg_uri")] public Uri IconSvgUri { get; set; } = new(Constants.Localhost);
    [JsonProperty("search_uri")] public Uri SearchUri { get; set; } = new(Constants.Localhost);
}