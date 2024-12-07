using MemoryPack;
using EIV_JsonLib.Formatter;
using EIV_JsonLib.Base;

namespace EIV_JsonLib;

public static class FormatterInitializer
{
    public static void RegisterFormatter()
    {
        if (!MemoryPackFormatterProvider.IsRegistered<CoreItem>())
        {
            MemoryPackFormatterProvider.Register(new CustomCoreItemFormatter());
        }

        if (!MemoryPackFormatterProvider.IsRegistered<CoreUsable>())
        {
            MemoryPackFormatterProvider.Register(new CustomCoreUsableFormatter());
        }

        if (!MemoryPackFormatterProvider.IsRegistered<CoreArmor>())
        {
            MemoryPackFormatterProvider.Register(new CustomCoreArmorFormatter());
        }
    }
}
