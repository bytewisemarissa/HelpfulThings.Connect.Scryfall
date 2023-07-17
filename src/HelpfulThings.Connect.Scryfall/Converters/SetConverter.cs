using HelpfulThings.Connect.Scryfall.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelpfulThings.Connect.Scryfall.Converters;

public class SetConverter : Newtonsoft.Json.JsonConverter<Set>
{
    public override void WriteJson(JsonWriter writer, Set? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override Set? ReadJson(JsonReader reader, Type objectType, Set? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var semiParsed = JObject.Load(reader);

        return null;
    }
}