using MemoryPack;
using EIV_JsonLib.Formatter;
using EIV_JsonLib.Base;

namespace EIV_JsonLib;

public static class FormatterInitializer
{
    public static void RegisterFormatter()
    {
        if (!MemoryPackFormatterProvider.IsRegistered<ItemBase>())
        {
            MemoryPackFormatterProvider.Register(new CustomItemBaseFormatter());
        }

        if (!MemoryPackFormatterProvider.IsRegistered<UsableItemBase>())
        {
            MemoryPackFormatterProvider.Register(new CustomUsableItemBaseFormatter());
        }

        if (!MemoryPackFormatterProvider.IsRegistered<ArmorBase>())
        {
            MemoryPackFormatterProvider.Register(new CustomArmorBaseFormatter());
        }
    }
}
