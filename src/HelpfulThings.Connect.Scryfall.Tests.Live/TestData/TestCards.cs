namespace HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

/// <summary>
/// Only the fields of a card that are stable day to day. Prices, image cache-busting
/// timestamps, affiliate URLs, and similar drift constantly and must not be asserted here.
/// </summary>
public record StableCardFields
{
    public required Guid ScryfallId { get; init; }
    public Guid? OracleId { get; init; }
    public string? Name { get; init; }
    public string SetCode { get; init; } = string.Empty;
    public string CollectorNumber { get; init; } = string.Empty;
    public required string Layout { get; init; }
    public required string Rarity { get; init; }
    public DateOnly ReleasedAt { get; init; }
    public string? ArtistName { get; init; }
    public int[]? MultiverseIds { get; init; }
    public int? MtgoId { get; init; }
    public int? ArenaId { get; init; }
    public int? TcgPlayerId { get; init; }
    public int? CardmarketId { get; init; }
}

public static class TestCards
{
    public static readonly StableCardFields BlackLotus1StEd = new()
    {
        ScryfallId = new("b0faa7f2-b547-42c4-a810-839da50dadfe"),
        OracleId = new("5089ec1a-f881-4d55-af14-5d996171203b"),
        Name = "Black Lotus",
        SetCode = "lea",
        CollectorNumber = "232",
        Layout = "normal",
        Rarity = "rare",
        ReleasedAt = new(1993, 8, 5),
        ArtistName = "Christopher Rush",
        MultiverseIds = [3],
        MtgoId = 347,
        TcgPlayerId = 1042,
        CardmarketId = 5465
    };

    public static readonly StableCardFields DereviEmpyrialTactician = new()
    {
        ScryfallId = new("3a1d0dad-18a8-489e-ac11-08f64b72fda4"),
        OracleId = new("afa49a09-146f-4439-850e-dd1938c93cef"),
        Name = "Derevi, Empyrial Tactician",
        SetCode = "cma",
        CollectorNumber = "176",
        Layout = "normal",
        Rarity = "mythic",
        ReleasedAt = new(2017, 6, 9),
        ArtistName = "Michael Komarck",
        MultiverseIds = [430395],
        TcgPlayerId = 131911,
        CardmarketId = 298125
    };

    /// <summary>
    /// Black Lotus has an MTGO id but no Arena id. This is the newest Standard printing of
    /// Llanowar Elves at the time of writing, which does have one.
    /// </summary>
    public static readonly StableCardFields LlanowarElvesArena = new()
    {
        ScryfallId = new("6a0b230b-d391-4998-a3f7-7b158a0ec2cd"),
        OracleId = new("68954295-54e3-4303-a6bc-fc4547a4e3a3"),
        Name = "Llanowar Elves",
        SetCode = "fdn",
        CollectorNumber = "227",
        Layout = "normal",
        Rarity = "common",
        ReleasedAt = new(2024, 11, 15),
        ArtistName = "Kev Walker",
        MultiverseIds = [679969],
        MtgoId = 133480,
        ArenaId = 93940,
        TcgPlayerId = 557921,
        CardmarketId = 795132
    };
}
