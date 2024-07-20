using System.Text.Json;
using HelpfulThings.Connect.Scryfall.Identifiers;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace HelpfulThings.Connect.Scryfall.Converters;

public class IdentifierConverter : JsonConverter<List<Identifier>>
{
    public override void WriteJson(JsonWriter writer, List<Identifier>? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override List<Identifier>? ReadJson(JsonReader reader, Type objectType, List<Identifier>? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var returns = new List<Identifier>();

        //read into array struct
        reader.Read();
        
        while (reader.TokenType != JsonToken.EndArray)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    reader.Read();
                    continue;
                case JsonToken.PropertyName:
                    returns.Add(ReadIdentifier(reader));
                    break;
                case JsonToken.EndObject:
                    reader.Read();
                    continue;
            }
        }

        return returns;
    }

    private Identifier ReadIdentifier(JsonReader reader)
    {
        var propertyName = reader.Value;
        reader.Read();
        var propertyValue = reader.Value;
        reader.Read();

        if (propertyValue == null)
        {
            throw new NullReferenceException("Got null property value where one wasn't expected.");
        }

        switch (propertyName)
        {
            case "collector_number":
                var setPropertyName = reader.Value;
                reader.Read();
                var setValue = reader.Value;
                reader.Read();
                return new CollectorNumberSetIdentifier((propertyValue as string)!, (setValue as string)!);
            case "set":
                var nextPropertyName = reader.Value;
                reader.Read();
                var nextPropertyValue = reader.Value;
                reader.Read();
                switch ((string)nextPropertyName!)
                {
                    case "collector_number":
                        return new CollectorNumberSetIdentifier(
                            (nextPropertyValue as string)!, 
                        (propertyValue as string)!
                            );
                    case "name":
                        return new NameSetIdentifier(
                            (nextPropertyValue as string)!, 
                            (propertyValue as string)!);
                    default:
                        throw new NotImplementedException("Set should match with name or collector_number");
                }
            case "illustration_id":
                return new IllustrationIdentifier((propertyValue as string)!);
            case "mtgo_id":
                return new MtgoIdentifier((long)propertyValue);
            case "multiverse_id":
                return new MultiverseIdentifier((long)propertyValue);
            case "name":
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return new NameIdentifier((propertyValue as string)!);    
                }
                
                var nextPropertyNameSet = reader.Value;
                reader.Read();
                var nextPropertyValueSet = reader.Value;
                reader.Read();

                return new NameSetIdentifier(
                    (propertyValue as string)!, 
                    (nextPropertyValueSet as string)!
                );
            case "oracle_id":
                return new OracleIdentifier((propertyValue as string)!);
            case "id":
                return new ScryfallIdentifier((propertyValue as string)!);
            default:
                throw new NotImplementedException("Encountered an unknown identifier type");
        }
    }
}