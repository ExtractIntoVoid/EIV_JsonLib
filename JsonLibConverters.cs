using EIV_JsonLib.Modding;

namespace EIV_JsonLib;

public static class JsonLibConverters
{
#pragma warning disable CA2211 // Non-constant fields should not be visible
    public static List<IJsonLibConverter> ModdedConverters =
    [
        new Internal_JsonLibConverter()
    
    ];
#pragma warning restore CA2211 // Non-constant fields should not be visible
}
