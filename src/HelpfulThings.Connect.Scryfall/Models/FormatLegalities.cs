using HelpfulThings.Connect.Scryfall.Enums;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class FormatLegalities
{
    [JsonProperty("standard")] public Legalities Standard { get; set; }
    [JsonProperty("future")] public Legalities Future { get; set; }
    [JsonProperty("historic")] public Legalities Historic { get; set; }
    [JsonProperty("gladiator")] public Legalities Gladiator { get; set; }
    [JsonProperty("pioneer")] public Legalities Pioneer { get; set; }
    [JsonProperty("explorer")] public Legalities Explorer { get; set; }
    [JsonProperty("modern")] public Legalities Modern { get; set; }
    [JsonProperty("legacy")] public Legalities Legacy { get; set; }
    [JsonProperty("pauper")] public Legalities Pauper { get; set; }
    [JsonProperty("vintage")] public Legalities Vintage { get; set; }
    [JsonProperty("penny")] public Legalities Penny { get; set; }
    [JsonProperty("commander")] public Legalities Commander { get; set; }
    [JsonProperty("oathbreaker")] public Legalities Oathbreaker { get; set; }
    [JsonProperty("brawl")] public Legalities Brawl { get; set; }
    [JsonProperty("historicbrawl")] public Legalities HistoricBrawl { get; set; }
    [JsonProperty("alchemy")] public Legalities Alchemy { get; set; }
    [JsonProperty("paupercommander")] public Legalities PauperCommander { get; set; }
    [JsonProperty("duel")] public Legalities Duel { get; set; }
    [JsonProperty("oldschool")] public Legalities OldSchool { get; set; }
    [JsonProperty("premodern")] public Legalities PreModern { get; set; }
    [JsonProperty("predh")] public Legalities Predh { get; set; }
}