using System.Text.Json.Serialization;
using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelpfulThings.Connect.Scryfall.Models;

public class Card
{
    [JsonProperty("set_id")] public Guid ScryfallSetId { get; set; }
    [JsonProperty("arena_id")] public int? ArenaId { get; set; }
    [JsonProperty("id")] public Guid ScryfallId { get; set; }
    [JsonProperty("lang")] public string Language { get; set; }
    [JsonProperty("mtgo_id")] public int? MtgoId { get; set; }
    [JsonProperty("mtgo_foil_id")] public int? MtgoFoilId { get; set; }
    [JsonProperty("multiverse_ids")] public int[]? MultiverseIds { get; set; }
    [JsonProperty("tcgplayer_id")] public int? TcgPlayerId { get; set; }
    [JsonProperty("tcgplayer_etched_id")] public int? TcgPlayerEtchedId { get; set; }
    [JsonProperty("cardmarket_id")] public int? CardmarketId { get; set; }
    [JsonProperty("oracle_id")] public Guid OracleId { get; set; }
    [JsonProperty("prints_search_uri")] public Uri PrintsSearchUri { get; set; }
    [JsonProperty("rulings_uri")] public Uri RulingsUri { get; set; }
    [JsonProperty("scryfall_uri")] public Uri ScryfallUri { get; set; }
    [JsonProperty("uri")] public Uri ScryfallApiUri { get; set; }
    [JsonProperty("all_parts")] public RelatedCard[] RelatedCards { get; set; }
    [JsonProperty("card_faces")] public CardFace[]? CardFaces { get; set; }
    [JsonProperty("cmc")] public float? ConvertedManaCost { get; set; }
    [JsonProperty("color_identity")] public Colors[] ColorIdentities { get; set; }
    [JsonProperty("color_indicator")] public Colors[]? ColorIndicators { get; set; }
    [JsonProperty("colors")] public Colors[] Colors { get; set; }
    [JsonProperty("edhrec_rank")] public int? EdhrecRank { get; set; }
    [JsonProperty("hand_modifier")] public string? HandModifier { get; set; }
    [JsonProperty("keywords")] public string[] Keywords { get; set; }
    [JsonProperty("layout")] public CardLayouts Layout { get; set; }
    [JsonProperty("legalities")] public FormatLegalities Legalities { get; set; }
    [JsonProperty("life_modifier")] public string? LifeModifier { get; set; }
    [JsonProperty("loyalty")] public string? Loyalty { get; set; }
    [JsonProperty("mana_cost")] public string? ManaCost { get; set; }
    [JsonProperty("name")] public string? Name { get; set; }
    [JsonProperty("oracle_text")] public string? OracleText { get; set; }
    [JsonProperty("oversized")] public bool Oversized { get; set; }
    [JsonProperty("penny_rank")] public int? PennyDreadfulRank { get; set; }
    [JsonProperty("power")] public string? Power { get; set; }
    [JsonProperty("produced_mana")] public Colors[]? ProducedMana { get; set; }
    [JsonProperty("reserved")] public bool ReserveList { get; set; }
    [JsonProperty("foil")] public bool Foil { get; set; }
    [JsonProperty("nonfoil")] public bool NonFoil { get; set; }
    [JsonProperty("toughness")] public string? Toughness { get; set; }
    [JsonProperty("type_line")] public string TypeLine { get; set; }
    [JsonProperty("artist")] public string? ArtistName { get; set; }
    [JsonProperty("artist_ids")] public Guid[] ArtistIds { get; set; }
    [JsonProperty("attraction_lights")] public int[] AttractionLights { get; set; }
    [JsonProperty("booster")] public bool FoundInBoosters { get; set; }
    [JsonProperty("border_color")] public BorderColors BorderColor { get; set; }
    [JsonProperty("card_back_id")] public Guid BackDesignScryfallId { get; set; }
    [JsonProperty("collector_number")] public string CollectorNumber { get; set; }
    [JsonProperty("content_warning")] public bool? ContentWarning { get; set; }
    [JsonProperty("digital")] public bool Digital { get; set; }
    [JsonProperty("finishes")] public Finishes[] Finishes { get; set; }
    [JsonProperty("flavor_name")] public string? FlavorName { get; set; }
    [JsonProperty("flavor_text")] public string? FlavorText { get; set; }
    [JsonProperty("frame_effects")] public FrameEffects[] FrameEffects { get; set; }
    [JsonProperty("frame")] public Frames Frame { get; set; }
    [JsonProperty("full_art")] public bool FullArt { get; set; }
    [JsonProperty("games")] public Games[] Games { get; set; }
    [JsonProperty("highres_image")] public bool HighResolutionScan { get; set; }
    [JsonProperty("image_uris")] public ImageUris ImageUris { get; set; }
    [JsonProperty("illustration_id")] public Guid? IllustrationId { get; set; }
    [JsonProperty("image_status")] public ImageStatuses ImageStatus { get; set; }
    [JsonProperty("prices")] public CardPrices Prices { get; set; }
    [JsonProperty("printed_name")] public string? PrintedName { get; set; }
    [JsonProperty("printed_text")] public string? PrintedText { get; set; }
    [JsonProperty("printed_type_line")] public string? PrintedTypeLine { get; set; }
    [JsonProperty("promo")] public bool Promo { get; set; }
    [JsonProperty("promo_types")] public string[]? PromoTypes { get; set; }
    [JsonProperty("purchase_uris")] public PurchaseUris PurchaseUris { get; set; }
    [JsonProperty("rarity")] public CardRarities Rarity { get; set; }
    [JsonProperty("related_uris")] public RelatedUris RelatedUris { get; set; }
    [JsonProperty("released_at")] public DateOnly ReleasedAt { get; set; }
    [JsonProperty("reprint")] public bool Reprint { get; set; }
    [JsonProperty("scryfall_set_uri")] public Uri ScryfallSetUri { get; set; }
    [JsonProperty("set_name")] public string SetName { get; set; }
    [JsonProperty("set_search_uri")] public Uri SetSearchUri { get; set; }
    [JsonProperty("set_type")] public SetTypes SetType { get; set; }
    [JsonProperty("set_uri")] public Uri SetUri { get; set; }
    [JsonProperty("story_spotlight")] public bool StorySpotlight { get; set; }
    [JsonProperty("textless")] public bool Textless { get; set; }
    [JsonProperty("variation")] public bool Variation { get; set; }
    [JsonProperty("variation_of")] public Guid? VariationOf { get; set; }
    [JsonProperty("security_stamp")] public SecurityStamps SecurityStamp { get; set; }
    [JsonProperty("watermark")] public string? Watermark { get; set; }
    [JsonProperty("preview.previewed_at")] public DateOnly? PreviewedAt { get; set; }
    [JsonProperty("preview.source_uri")] public Uri? PreviewSourceUri { get; set; }
    [JsonProperty("preview.source")] public string? PreviewSource { get; set; }
    [JsonProperty("set")] public string SetCode { get; set; }

    public Card()
    {
        Language = string.Empty;
        PrintsSearchUri = new Uri(Constants.Localhost);
        RulingsUri = new Uri(Constants.Localhost);
        ScryfallUri = new Uri(Constants.Localhost);
        ScryfallApiUri = new Uri(Constants.Localhost);
        RelatedCards = Array.Empty<RelatedCard>();
        ColorIdentities = Array.Empty<Colors>();
        Colors = Array.Empty<Colors>();
        Keywords = Array.Empty<string>();
        Legalities = new FormatLegalities();
        TypeLine = string.Empty;
        ArtistIds = Array.Empty<Guid>();
        AttractionLights = Array.Empty<int>();
        CollectorNumber = string.Empty;
        Finishes = Array.Empty<Finishes>();
        FrameEffects = Array.Empty<FrameEffects>();
        Games = Array.Empty<Games>();
        ImageUris = new ImageUris();
        Prices = new CardPrices();
        PurchaseUris = new PurchaseUris();
        RelatedUris = new RelatedUris();
        ScryfallSetUri = new Uri(Constants.Localhost);
        SetName = string.Empty;
        SetSearchUri = new Uri(Constants.Localhost);
        SetUri = new Uri(Constants.Localhost);
        SetCode = string.Empty;
    }
}