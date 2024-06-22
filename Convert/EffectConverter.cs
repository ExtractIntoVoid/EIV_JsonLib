using EIV_JsonLib.Interfaces;
using EIV_JsonLib.Defaults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EIV_JsonLib.Convert;

public class EffectConverter : JsonConverter<IEffect>
{
    public override IEffect? ReadJson(JsonReader reader, Type objectType, IEffect? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var @default = new DefaultEffect();
        var jsonObject = JObject.Load(reader);
        serializer.Populate(jsonObject.CreateReader(), @default);
        return @default;
    }

    public override void WriteJson(JsonWriter writer, IEffect? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
