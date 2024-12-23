using MemoryPack;
using EIV_JsonLib.Formatter;
using EIV_JsonLib.Base;
using EIV_JsonLib.Profile.ProfileModules;
using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib;

public static class FormatterInitializer
{
    public static CustomFormatter<CoreItem> CoreItem_Formatter = new();
    public static CustomFormatter<CoreUsable> CoreUsable_Formatter = new();
    public static CustomFormatter<CoreArmor> CoreArmor_Formatter = new();
    public static CustomFormatter<IProfileModule> IProfileModule_Formatter = new();
    public static CustomFormatter<IDamageDealer> IDamageDealer_Formatter = new();
    public static CustomFormatter<IDurable> IDurable_Formatter = new();
    public static CustomFormatter<IWearable> IWearable_Formatter = new();
    public static CustomFormatter<IStorage> IStorage_Formatter = new();

    /// <summary>
    /// Register Core Formatters if the type is not registered yet.
    /// </summary>
    public static void RegisterFormatter()
    {
        // CoreItem
        if (!MemoryPackFormatterProvider.IsRegistered<CoreItem>())
        {
            CoreItem_Formatter = new();
            CoreItem_Formatter.AddToTag<CoreUsable>();
            CoreItem_Formatter.AddToTag<CoreArmor>();
            CoreItem_Formatter.AddToTag<Backpack>();
            CoreItem_Formatter.AddToTag<Ammo>();
            CoreItem_Formatter.AddToTag<Magazine>();
            CoreItem_Formatter.AddToTag<GunMod>();
            CoreItem_Formatter.AddToTag<ArmorPlate>();
            MemoryPackFormatterProvider.Register(CoreItem_Formatter);
        }

        // CoreUsable
        if (!MemoryPackFormatterProvider.IsRegistered<CoreUsable>())
        {
            CoreUsable_Formatter = new();
            CoreUsable_Formatter.AddToTag<Consumable>();
            CoreUsable_Formatter.AddToTag<Throwable>();
            CoreUsable_Formatter.AddToTag<Melee>();
            CoreUsable_Formatter.AddToTag<Gun>();
            CoreUsable_Formatter.AddToTag<Healing>();
            MemoryPackFormatterProvider.Register(CoreUsable_Formatter);
        }

        // CoreArmor
        if (!MemoryPackFormatterProvider.IsRegistered<CoreArmor>())
        {
            CoreArmor_Formatter = new();
            CoreArmor_Formatter.AddToTag<Rig>();
            CoreArmor_Formatter.AddToTag<Helmet>();
            CoreArmor_Formatter.AddToTag<Vest>();
            MemoryPackFormatterProvider.Register(CoreArmor_Formatter);
        }

        // IProfileModule
        if (!MemoryPackFormatterProvider.IsRegistered<IProfileModule>())
        {
            IProfileModule_Formatter = new();
            // Maybe add ALL regular type?
            IProfileModule_Formatter.AddToTag<StatusEffectModule>();
            IProfileModule_Formatter.AddToTag<MinMaxValueModule<int>>();
            IProfileModule_Formatter.AddToTag<MinMaxValueModule<float>>();
            IProfileModule_Formatter.AddToTag<MinMaxValueModule<decimal>>();
            IProfileModule_Formatter.AddToTag<MinMaxValueModule<object>>();
            IProfileModule_Formatter.AddToTag<MinMaxValueModule<bool>>();
            IProfileModule_Formatter.AddToTag<ValueModule<int>>();
            IProfileModule_Formatter.AddToTag<ValueModule<float>>();
            IProfileModule_Formatter.AddToTag<ValueModule<decimal>>();
            IProfileModule_Formatter.AddToTag<ValueModule<string>>();
            IProfileModule_Formatter.AddToTag<ValueModule<bool>>();
            IProfileModule_Formatter.AddToTag<ValueModule<object>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<int>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<float>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<decimal>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<string>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<bool>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<object>>();
            MemoryPackFormatterProvider.Register(IProfileModule_Formatter);
        }

        // IDamageDealer
        if (!MemoryPackFormatterProvider.IsRegistered<IDamageDealer>())
        {
            IDamageDealer_Formatter = new();
            IDamageDealer_Formatter.AddToTag<Ammo>();
            IDamageDealer_Formatter.AddToTag<Melee>();
            MemoryPackFormatterProvider.Register(IDamageDealer_Formatter);
        }

        // IDurable
        if (!MemoryPackFormatterProvider.IsRegistered<IDurable>())
        {
            IDurable_Formatter = new();
            IDurable_Formatter.AddToTag<ArmorPlate>();
            MemoryPackFormatterProvider.Register(IDurable_Formatter);
        }

        // IWearable
        if (!MemoryPackFormatterProvider.IsRegistered<IWearable>())
        {
            IWearable_Formatter = new();
            IWearable_Formatter.AddToTag<CoreArmor>();
            IWearable_Formatter.AddToTag<Backpack>();
            MemoryPackFormatterProvider.Register(IWearable_Formatter);
        }

        // IWearable
        if (!MemoryPackFormatterProvider.IsRegistered<IStorage>())
        {
            IStorage_Formatter = new();
            IStorage_Formatter.AddToTag<Rig>();
            IStorage_Formatter.AddToTag<Backpack>();
            IStorage_Formatter.AddToTag<Stash>();
            MemoryPackFormatterProvider.Register(IStorage_Formatter);
        }
    }
}
