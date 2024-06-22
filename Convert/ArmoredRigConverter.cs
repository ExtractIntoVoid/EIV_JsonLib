using EIV_JsonLib.Interfaces;
using EIV_JsonLib.Defaults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EIV_JsonLib.Convert;

public class ArmoredRigConverter : JsonConverter<IArmoredRig>
{
    public override IArmoredRig? ReadJson(JsonReader reader, Type objectType, IArmoredRig? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var item = new DefaultArmoredRig();
        var jsonObject = JObject.Load(reader);
        serializer.Populate(jsonObject.CreateReader(), item);
        return item;
    }

    public override void WriteJson(JsonWriter writer, IArmoredRig? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
