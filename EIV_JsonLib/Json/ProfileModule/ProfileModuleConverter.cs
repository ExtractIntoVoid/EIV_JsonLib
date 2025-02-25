using System.Text.Json.Serialization;
using System.Text.Json;
using EIV_JsonLib.Profile.ProfileModules;

namespace EIV_JsonLib.Json;

public class ProfileModuleConverter : JsonConverter<IProfileModule>
{
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
}
