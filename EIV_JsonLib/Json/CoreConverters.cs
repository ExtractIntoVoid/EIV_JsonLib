namespace EIV_Items.Json;

public static class CoreConverters
{
    public static List<IJsonLibConverter> Converters =
    [
        new Internal_CoreItemConverter(),
        new Internal_ProfileModuleConverter(),
    ];
}
