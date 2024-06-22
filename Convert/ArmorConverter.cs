using EIV_JsonLib.Interfaces;
using EIV_JsonLib.Defaults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EIV_JsonLib.Convert;

public class ArmorConverter : JsonConverter<IArmor>
{
    public override IArmor? ReadJson(JsonReader reader, Type objectType, IArmor? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var item = new DefaultArmor();
        var jsonObject = JObject.Load(reader);
        serializer.Populate(jsonObject.CreateReader(), item);
        return item;
    }

    public override void WriteJson(JsonWriter writer, IArmor? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
