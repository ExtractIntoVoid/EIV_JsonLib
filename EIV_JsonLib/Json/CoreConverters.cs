namespace EIV_JsonLib.Json;

public static class CoreConverters
{
    public static List<IJsonLibConverter> Converters =
    [
        new Internal_CoreItemConverter(),
        new Internal_ProfileModuleConverter(),
    ];
}
