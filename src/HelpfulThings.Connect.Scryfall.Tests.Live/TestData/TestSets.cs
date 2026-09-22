namespace HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

/// <summary>
/// Only the fields of a set that are stable day to day. IconSvgUri (cache-busting timestamp)
/// and CardCount (grows as new cards are added to the set) must not be asserted here.
/// </summary>
public record StableSetFields
{
    public required Guid ScryfallId { get; init; }
    public required string Code { get; init; }
    public required string Name { get; init; }
    public required string SetType { get; init; }
    public DateTime? ReleasedAt { get; init; }
    public int? TcgPlayerId { get; init; }
}

public static class TestSets
{
    public static readonly StableSetFields CommanderMasters = new()
    {
        ScryfallId = new("cd05036f-2698-43e6-a48e-5c8d82f0a551"),
        Code = "cmm",
        Name = "Commander Masters",
        SetType = "masters",
        ReleasedAt = new DateTime(2023, 8, 4),
        TcgPlayerId = 23020
    };

    public static readonly StableSetFields CommanderAnthology = new()
    {
        ScryfallId = new("fd4d8463-0156-4c60-a40e-778762bb90e4"),
        Code = "cma",
        Name = "Commander Anthology",
        SetType = "commander",
        ReleasedAt = new DateTime(2017, 6, 9),
        TcgPlayerId = 1933
    };
}
