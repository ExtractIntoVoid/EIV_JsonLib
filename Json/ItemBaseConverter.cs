using EIV_JsonLib.Base;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EIV_JsonLib.Json;

public class ItemBaseConverter : JsonConverter<CoreItem>
{
    public override CoreItem? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var clone = JsonDocument.ParseValue(ref reader).RootElement.Clone();
        if (!clone.TryGetProperty("ItemType", out var ItemTypeElement))
            throw new JsonException("ItemType not found!");
        string? ItemType = ItemTypeElement.GetString();
        ArgumentNullException.ThrowIfNull(ItemType);
        var converter = CoreConverters.Converters.FirstOrDefault(x => x.GetType(ItemType) != null);
        if (converter == null)
            throw new JsonException("CoreConverters could not find any type to convert to.");
        var info = options.GetTypeInfo(converter.GetType(ItemType)!);
        return (CoreItem?)JsonSerializer.Deserialize(clone, info);
    }

    public override void Write(Utf8JsonWriter writer, CoreItem value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
