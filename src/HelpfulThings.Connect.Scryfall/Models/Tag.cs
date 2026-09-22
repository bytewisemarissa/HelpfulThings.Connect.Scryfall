using Newtonsoft.Json;

namespace HelpfulThings.Connect.Scryfall.Models;

public class Tag
{
    [JsonProperty("id")] public Guid Id { get; set; }
    [JsonProperty("slug")] public string Slug { get; set; } = string.Empty;
    [JsonProperty("label")] public string Label { get; set; } = string.Empty;
    [JsonProperty("uri")] public Uri Uri { get; set; } = new(Constants.Localhost);
    [JsonProperty("type")] public string Type { get; set; } = string.Empty;
    [JsonProperty("description")] public string? Description { get; set; }
    [JsonProperty("parent_ids")] public Guid[]? ParentIds { get; set; }
    [JsonProperty("child_ids")] public Guid[]? ChildIds { get; set; }
    [JsonProperty("aliases")] public string[]? Aliases { get; set; }
    [JsonProperty("taggings")] public Tagging[] Taggings { get; set; } = [];
}
