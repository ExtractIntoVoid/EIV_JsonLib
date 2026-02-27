using EIV_JsonLib.Profile.ProfileModules;

#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
using System.Text.Json;
#else
using Newtonsoft.Json;
#endif

namespace EIV_JsonLib.Json;

public class ProfileModuleConverter : JsonConverter<IProfileModule>
{
#if NET8_0_OR_GREATER
    public override IProfileModule? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var clone = JsonDocument.ParseValue(ref reader).RootElement.Clone();
        if (!clone.TryGetProperty("ModuleType", out var ModuleTypeElement))
            throw new JsonException("ModuleType not found!");
        string? ModuleType = ModuleTypeElement.GetString();
        ArgumentNullException.ThrowIfNull(ModuleType);
        var converter = CoreConverters.Converters.FirstOrDefault(x => x.GetType(ModuleType) != null) ?? throw new JsonException("CoreConverters could not find any type to convert to.");
        var info = options.GetTypeInfo(converter.GetType(ModuleType)!);
        var module = (IProfileModule?)JsonSerializer.Deserialize(clone, info);
        if (module != null)
            module.ModuleType = info.GetType().ToString();
        return module;
    }

    public override void Write(Utf8JsonWriter writer, IProfileModule value, JsonSerializerOptions options)
    {
        var type = value.GetType();
        value.ModuleType = NameWithGenerics(type);
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }

    public string NameWithGenerics(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (type.IsArray)
            return $"{type.GetElementType()?.Name}[]";

        if (!type.IsGenericType)
            return type.Name;

        var name = type.GetGenericTypeDefinition().Name;
        var index = name.IndexOf('`');
        var newName = index == -1 ? name : name[..index];

        var list = type.GetGenericArguments().Select(NameWithGenerics).ToList();
        return $"{newName}|{string.Join(",", list)}";
    }
#else
    public override IProfileModule? ReadJson(JsonReader reader, Type objectType, IProfileModule? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        Console.WriteLine(objectType.FullName);

        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, IProfileModule? value, JsonSerializer serializer)
    {
        if (value == null)
            return;

        var type = value.GetType();
        value.ModuleType = NameWithGenerics(type);
        serializer.Serialize(writer, value);
    }

    public string NameWithGenerics(Type type)
    {
        if (type == null)
            return string.Empty;

        if (type.IsArray)
            return $"{type.GetElementType()?.Name}[]";

        if (!type.IsGenericType)
            return type.Name;

        var name = type.GetGenericTypeDefinition().Name;
        var index = name.IndexOf('`');
        var newName = index == -1 ? name : name.Take(index);

        var list = type.GetGenericArguments().Select(NameWithGenerics).ToList();
        return $"{newName}|{string.Join(",", list)}";
    }
#endif
}
