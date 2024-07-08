using EIV_JsonLib.Interfaces;
using EIV_JsonLib.Defaults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EIV_JsonLib.Convert;

public class ConsumableConverter : JsonConverter<IConsumable>
{
    public override IConsumable? ReadJson(JsonReader reader, Type objectType, IConsumable? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var @default = new DefaultConsumable();
        var jsonObject = JObject.Load(reader);
        serializer.Populate(jsonObject.CreateReader(), @default);
        return @default;
    }

    public override void WriteJson(JsonWriter writer, IConsumable? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
