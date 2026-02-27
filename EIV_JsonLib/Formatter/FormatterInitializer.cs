using EIV_JsonLib.Base;
using EIV_JsonLib.Profile.ProfileModules;
using EIV_JsonLib.Interfaces;
using EIV_Pack;
using EIV_Pack.Formatters;

namespace EIV_JsonLib.Formatter;

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
        // Register formatters here before we do something.
        Backpack.RegisterFormatter();
        Ammo.RegisterFormatter();
        Magazine.RegisterFormatter();
        GunMod.RegisterFormatter();
        ArmorPlate.RegisterFormatter();
        Consumable.RegisterFormatter();
        Throwable.RegisterFormatter();
        Melee.RegisterFormatter();
        Gun.RegisterFormatter();
        Healing.RegisterFormatter();
        Rig.RegisterFormatter();
        Helmet.RegisterFormatter();
        Vest.RegisterFormatter();
        Ammo.RegisterFormatter();
        ArmorPlate.RegisterFormatter();
        Backpack.RegisterFormatter();
        Stash.RegisterFormatter();

        // CoreItem
        if (!FormatterProvider.IsRegistered<CoreItem>())
        {
            CoreItem_Formatter.AddToTag<CoreUsable>();
            CoreItem_Formatter.AddToTag<CoreArmor>();
            CoreItem_Formatter.AddToTag<Backpack>();
            CoreItem_Formatter.AddToTag<Ammo>();
            CoreItem_Formatter.AddToTag<Magazine>();
            CoreItem_Formatter.AddToTag<GunMod>();
            CoreItem_Formatter.AddToTag<ArmorPlate>();
            FormatterProvider.Register(CoreItem_Formatter);
            FormatterProvider.Register(new ListFormatter<CoreItem>());
        }


        // CoreUsable
        if (!FormatterProvider.IsRegistered<CoreUsable>())
        {
            CoreUsable_Formatter.AddToTag<Consumable>();
            CoreUsable_Formatter.AddToTag<Throwable>();
            CoreUsable_Formatter.AddToTag<Melee>();
            CoreUsable_Formatter.AddToTag<Gun>();
            CoreUsable_Formatter.AddToTag<Healing>();
            FormatterProvider.Register(CoreUsable_Formatter);
            FormatterProvider.Register(new ListFormatter<CoreUsable>());
        }

        // CoreArmor
        if (!FormatterProvider.IsRegistered<CoreArmor>())
        {
            CoreArmor_Formatter.AddToTag<Rig>();
            CoreArmor_Formatter.AddToTag<Helmet>();
            CoreArmor_Formatter.AddToTag<Vest>();
            FormatterProvider.Register(CoreArmor_Formatter);
            FormatterProvider.Register(new ListFormatter<CoreArmor>());
        }


        // IProfileModule
        if (!FormatterProvider.IsRegistered<IProfileModule>())
        {
            // Maybe add ALL regular type?
            IProfileModule_Formatter.AddToTag<StatusEffectModule>();
            IProfileModule_Formatter.AddToTag<MinMaxValueModule<int>>();
            IProfileModule_Formatter.AddToTag<MinMaxValueModule<float>>();
            IProfileModule_Formatter.AddToTag<MinMaxValueModule<decimal>>();
            IProfileModule_Formatter.AddToTag<MinMaxValueModule<bool>>();
            IProfileModule_Formatter.AddToTag<ValueModule<int>>();
            IProfileModule_Formatter.AddToTag<ValueModule<float>>();
            IProfileModule_Formatter.AddToTag<ValueModule<decimal>>();
            IProfileModule_Formatter.AddToTag<ValueModule<string>>();
            IProfileModule_Formatter.AddToTag<ValueModule<bool>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<int>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<float>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<decimal>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<string>>();
            IProfileModule_Formatter.AddToTag<ReadOnlyValueModule<bool>>();
            FormatterProvider.Register(IProfileModule_Formatter);
            FormatterProvider.Register(new ListFormatter<IProfileModule>());
        }

        // IDamageDealer
        if (!FormatterProvider.IsRegistered<IDamageDealer>())
        {
            IDamageDealer_Formatter.AddToTag<Ammo>();
            IDamageDealer_Formatter.AddToTag<Melee>();
            FormatterProvider.Register(IDamageDealer_Formatter);
            FormatterProvider.Register(new ListFormatter<IDamageDealer>());
        }

        // IDurable
        if (!FormatterProvider.IsRegistered<IDurable>())
        {
            IDurable_Formatter.AddToTag<ArmorPlate>();
            FormatterProvider.Register(IDurable_Formatter);
            FormatterProvider.Register(new ListFormatter<IDurable>());
        }

        // IWearable
        if (!FormatterProvider.IsRegistered<IWearable>())
        {
            IWearable_Formatter.AddToTag<CoreArmor>();
            IWearable_Formatter.AddToTag<Backpack>();
            FormatterProvider.Register(IWearable_Formatter);
            FormatterProvider.Register(new ListFormatter<IWearable>());
        }

        // IStorage
        if (!FormatterProvider.IsRegistered<IStorage>())
        {
            IStorage_Formatter.AddToTag<Rig>();
            IStorage_Formatter.AddToTag<Backpack>();
            IStorage_Formatter.AddToTag<Stash>();
            FormatterProvider.Register(IStorage_Formatter);
            FormatterProvider.Register(new ListFormatter<IStorage>());
        }
    }
}
