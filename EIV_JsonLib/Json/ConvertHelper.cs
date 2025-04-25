using EIV_JsonLib.Base;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EIV_JsonLib.Json;

public static class ConvertHelper
{
    public static CoreItem? ConvertFromString(this string json, List<JsonConverter>? converters = null)
    {
        converters ??= [];
        var settings = GetSerializerSettings();
        foreach (var item in converters)
        {
            settings.Converters.Add(item);
        }
        return JsonSerializer.Deserialize<CoreItem>(json, settings);
    }

    public static JsonSerializerOptions GetSerializerSettings()
    {
        JsonSerializerOptions jsonSerializerSettings = new()
        {
            Converters = { },
            WriteIndented = true,
        };

        foreach (var item in CoreConverters.Converters)
        {
            if (item == null)
                continue;
            foreach (var converter in item.GetJsonConverters())
            {
                jsonSerializerSettings.Converters.Add(converter);
            }
        }
        return jsonSerializerSettings;
    }
}
