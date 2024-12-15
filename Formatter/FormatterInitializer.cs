using MemoryPack;
using EIV_JsonLib.Formatter;
using EIV_JsonLib.Base;

namespace EIV_JsonLib;

public static class FormatterInitializer
{
    /// <summary>
    /// Register Core Formatters if the type is not registered yet.
    /// </summary>
    public static void RegisterFormatter()
    {
        // CoreItem
        if (!MemoryPackFormatterProvider.IsRegistered<CoreItem>())
            MemoryPackFormatterProvider.Register(new CustomCoreItemFormatter());

        // CoreUsable
        if (!MemoryPackFormatterProvider.IsRegistered<CoreUsable>())
            MemoryPackFormatterProvider.Register(new CustomCoreUsableFormatter());

        // CoreArmor
        if (!MemoryPackFormatterProvider.IsRegistered<CoreArmor>())
            MemoryPackFormatterProvider.Register(new CustomCoreArmorFormatter());
    }
}
