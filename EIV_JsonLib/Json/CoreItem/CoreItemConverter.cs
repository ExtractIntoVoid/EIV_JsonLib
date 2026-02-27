using EIV_JsonLib.Base;
#if NET8_0_OR_GREATER
using System.Text.Json;
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json;
#endif

namespace EIV_JsonLib.Json;

public class CoreItemConverter : JsonConverter<CoreItem>
{
#if NET8_0_OR_GREATER
    public override CoreItem? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var clone = JsonDocument.ParseValue(ref reader).RootElement.Clone();
        if (!clone.TryGetProperty("ItemType", out var ItemTypeElement))
            throw new JsonException("ItemType not found!");
        string? ItemType = ItemTypeElement.GetString();
        ArgumentNullException.ThrowIfNull(ItemType);
        var converter = CoreConverters.Converters.FirstOrDefault(x => x.GetType(ItemType) != null) ?? throw new JsonException("CoreConverters could not find any type to convert to.");
        var info = options.GetTypeInfo(converter.GetType(ItemType)!);
        return (CoreItem?)JsonSerializer.Deserialize(clone, info);
    }

    public override void Write(Utf8JsonWriter writer, CoreItem value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
#else
    public override CoreItem? ReadJson(JsonReader reader, Type objectType, CoreItem? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, CoreItem? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
#endif
}
