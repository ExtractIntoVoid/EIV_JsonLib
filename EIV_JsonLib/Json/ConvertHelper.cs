using EIV_JsonLib.Base;
#if NET8_0_OR_GREATER
using System.Text.Json;
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json;
#endif


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
#if NET8_0_OR_GREATER
        return JsonSerializer.Deserialize<CoreItem>(json, settings);
#else
        return JsonConvert.DeserializeObject<CoreItem>(json, settings);
#endif
    }

#if NET8_0_OR_GREATER
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
#else
    public static JsonSerializerSettings GetSerializerSettings()
    {
        JsonSerializerSettings jsonSerializerSettings = new()
        {
            Converters = { },
            Formatting = Formatting.Indented,
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
#endif
}
