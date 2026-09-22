using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Identifiers;
using HelpfulThings.Connect.Scryfall.RequestResponse.Request;
using HelpfulThings.Connect.Scryfall.RequestResponse.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelpfulThings.Connect.Scryfall.Tests;

public class IdentifierConverterTests
{
    /// <summary>
    /// CollectionRequest.Identifiers has no JsonConverter attached (only CollectionResponse.NotFound
    /// does), so a request only ever needs to serialize, never deserialize. Inspect the produced
    /// JSON directly instead of round-tripping it back into a List&lt;Identifier&gt;.
    /// </summary>
    [Test]
    public void CollectionRequest_WithEveryIdentifierType_SerializesToScryfallShape()
    {
        var request = new CollectionRequest
        {
            Identifiers =
            [
                new CollectorNumberSetIdentifier("232", "lea"),
                new IllustrationIdentifier { IllustrationId = new Guid("54436824-977b-4dc7-8de1-8498e73e5ef2") },
                new MtgoIdentifier { MtgoId = 347 },
                new MultiverseIdentifier { MultiverseId = 3 },
                new NameIdentifier { Name = "Black Lotus" },
                new NameSetIdentifier("Black Lotus", "lea"),
                new OracleIdentifier { OracleId = new Guid("5089ec1a-f881-4d55-af14-5d996171203b") },
                new ScryfallIdentifier { ScryfallId = new Guid("b0faa7f2-b547-42c4-a810-839da50dadfe") }
            ]
        };

        var identifiers = (JArray)JObject.Parse(JsonConvert.SerializeObject(request))["identifiers"]!;

        identifiers.Should().HaveCount(8);
        AssertSameJson(identifiers[0], """{"collector_number":"232","set":"lea"}""");
        AssertSameJson(identifiers[1], """{"illustration_id":"54436824-977b-4dc7-8de1-8498e73e5ef2"}""");
        AssertSameJson(identifiers[2], """{"mtgo_id":347}""");
        AssertSameJson(identifiers[3], """{"multiverse_id":3}""");
        AssertSameJson(identifiers[4], """{"name":"Black Lotus"}""");
        AssertSameJson(identifiers[5], """{"name":"Black Lotus","set":"lea"}""");
        AssertSameJson(identifiers[6], """{"oracle_id":"5089ec1a-f881-4d55-af14-5d996171203b"}""");
        AssertSameJson(identifiers[7], """{"id":"b0faa7f2-b547-42c4-a810-839da50dadfe"}""");
    }

    private static void AssertSameJson(JToken actual, string expectedJson) =>
        JToken.DeepEquals(actual, JObject.Parse(expectedJson))
            .Should().BeTrue($"expected {actual} to equal {expectedJson}");

    [Test]
    public void CollectionResponse_NotFound_WithEveryIdentifierType_RoundTripsThroughIdentifierConverter()
    {
        var response = new CollectionResponse
        {
            NotFound =
            [
                new CollectorNumberSetIdentifier("232", "lea"),
                new IllustrationIdentifier { IllustrationId = new Guid("54436824-977b-4dc7-8de1-8498e73e5ef2") },
                new MtgoIdentifier { MtgoId = 347 },
                new MultiverseIdentifier { MultiverseId = 3 },
                new NameIdentifier { Name = "Black Lotus" },
                new NameSetIdentifier("Black Lotus", "lea"),
                new OracleIdentifier { OracleId = new Guid("5089ec1a-f881-4d55-af14-5d996171203b") },
                new ScryfallIdentifier { ScryfallId = new Guid("b0faa7f2-b547-42c4-a810-839da50dadfe") }
            ]
        };

        var json = JsonConvert.SerializeObject(response);
        var roundTripped = JsonConvert.DeserializeObject<CollectionResponse>(json);

        roundTripped!.NotFound.Select(i => i.GetType()).Should().Equal(
            typeof(CollectorNumberSetIdentifier),
            typeof(IllustrationIdentifier),
            typeof(MtgoIdentifier),
            typeof(MultiverseIdentifier),
            typeof(NameIdentifier),
            typeof(NameSetIdentifier),
            typeof(OracleIdentifier),
            typeof(ScryfallIdentifier));
    }

    /// <summary>
    /// Scryfall's own JSON doesn't guarantee property order. The converter reads a two-property
    /// identifier by whichever key comes first, so both orderings must parse to the same result.
    /// </summary>
    [TestCase("""{"collector_number":"not-found","set":"unt"}""")]
    [TestCase("""{"set":"unt","collector_number":"not-found"}""")]
    public void NotFoundEcho_CollectorNumberSetIdentifier_ParsesRegardlessOfPropertyOrder(string json)
    {
        var response = JsonConvert.DeserializeObject<CollectionResponse>(
            $$"""{ "not_found": [ {{json}} ], "data": [] }""")!;

        var identifier = response.NotFound.Single().Should().BeOfType<CollectorNumberSetIdentifier>().Subject;
        identifier.CollectorNumber.Should().Be("not-found");
        identifier.Set.Should().Be("unt");
    }

    [Test]
    public void NotFoundEcho_NameSetIdentifier_ParsesWithSetAfterName()
    {
        const string json = """{ "not_found": [ {"name":"not-found","set":"unt"} ], "data": [] }""";

        var response = JsonConvert.DeserializeObject<CollectionResponse>(json)!;

        var identifier = response.NotFound.Single().Should().BeOfType<NameSetIdentifier>().Subject;
        identifier.Name.Should().Be("not-found");
        identifier.Set.Should().Be("unt");
    }

    [Test]
    public void NotFoundEcho_EveryOtherIdentifierType_DeserializesToItsConcreteType()
    {
        const string json = """
            {
              "not_found": [
                { "name": "not-found" },
                { "id": "0001b119-a224-4d24-879c-aeb2cc9861a1" },
                { "oracle_id": "0001b119-a224-4d24-879c-aeb2cc9861a1" },
                { "mtgo_id": 999 },
                { "multiverse_id": 999999 },
                { "illustration_id": "0001b119-a224-4d24-879c-aeb2cc9861a1" }
              ],
              "data": []
            }
            """;

        var response = JsonConvert.DeserializeObject<CollectionResponse>(json)!;

        response.NotFound.Select(i => i.GetType()).Should().Equal(
            typeof(NameIdentifier),
            typeof(ScryfallIdentifier),
            typeof(OracleIdentifier),
            typeof(MtgoIdentifier),
            typeof(MultiverseIdentifier),
            typeof(IllustrationIdentifier));
    }
}
