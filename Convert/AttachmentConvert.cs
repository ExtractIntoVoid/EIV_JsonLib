using EIV_JsonLib.DefaultItems;
using EIV_JsonLib.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EIV_JsonLib.Convert;

public class AttachmentConvert : JsonConverter<IAttachment>
{
    public override IAttachment? ReadJson(JsonReader reader, Type objectType, IAttachment? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var item = new DefaultAttachment();
        var jsonObject = JObject.Load(reader);
        serializer.Populate(jsonObject.CreateReader(), item);
        return item;
    }

    public override void WriteJson(JsonWriter writer, IAttachment? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
