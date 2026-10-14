using EIV_Items.Core;
using EIV_Items.Interfaces;
using EIV_Pack;

namespace EIV_Items;

/// <summary>
/// Provides formatters.
/// </summary>
public static class FormatterInitializer
{
    /// <summary>
    /// Gets the <see cref="CoreItem"/> formatter.
    /// </summary>
    public static CoreCustomFormatter<CoreItem> CoreItem_Formatter { get; } = new();

    /// <summary>
    /// Gets the <see cref="CoreUsable"/> formatter.
    /// </summary>
    public static CoreCustomFormatter<CoreUsable> CoreUsable_Formatter { get; } = new();

    /// <summary>
    /// Gets the <see cref="CoreArmor"/> formatter.
    /// </summary>
    public static CoreCustomFormatter<CoreArmor> CoreArmor_Formatter { get; } = new();

    /// <summary>
    /// Gets the <see cref="IDamageDealer"/> formatter.
    /// </summary>
    public static CoreCustomFormatter<IDamageDealer> IDamageDealer_Formatter { get; } = new();

    /// <summary>
    /// Gets the <see cref="IDurable"/> formatter.
    /// </summary>
    public static CoreCustomFormatter<IDurable> IDurable_Formatter { get; } = new();

    /// <summary>
    /// Gets the <see cref="IWearable"/> formatter.
    /// </summary>
    public static CoreCustomFormatter<IWearable> IWearable_Formatter { get; } = new();

    /// <summary>
    /// Gets the <see cref="IStorage"/> formatter.
    /// </summary>
    public static CoreCustomFormatter<IStorage> IStorage_Formatter { get; } = new();

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
        Rig.RegisterFormatter();
        Helmet.RegisterFormatter();
        Vest.RegisterFormatter();
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
            FormatterProvider.RegisterCollection<CoreItem>();
        }

        // CoreUsable
        if (!FormatterProvider.IsRegistered<CoreUsable>())
        {
            CoreUsable_Formatter.AddToTag<Consumable>();
            CoreUsable_Formatter.AddToTag<Throwable>();
            CoreUsable_Formatter.AddToTag<Melee>();
            CoreUsable_Formatter.AddToTag<Gun>();
            FormatterProvider.Register(CoreUsable_Formatter);
            FormatterProvider.RegisterCollection<CoreUsable>();
        }

        // CoreArmor
        if (!FormatterProvider.IsRegistered<CoreArmor>())
        {
            CoreArmor_Formatter.AddToTag<Rig>();
            CoreArmor_Formatter.AddToTag<Helmet>();
            CoreArmor_Formatter.AddToTag<Vest>();
            FormatterProvider.Register(CoreArmor_Formatter);
            FormatterProvider.RegisterCollection<CoreArmor>();
        }

        // IDamageDealer
        if (!FormatterProvider.IsRegistered<IDamageDealer>())
        {
            IDamageDealer_Formatter.AddToTag<Ammo>();
            IDamageDealer_Formatter.AddToTag<Melee>();
            FormatterProvider.Register(IDamageDealer_Formatter);
            FormatterProvider.RegisterCollection<IDamageDealer>();
        }

        // IDurable
        if (!FormatterProvider.IsRegistered<IDurable>())
        {
            IDurable_Formatter.AddToTag<ArmorPlate>();
            FormatterProvider.Register(IDurable_Formatter);
            FormatterProvider.RegisterCollection<IDurable>();
        }

        // IWearable
        if (!FormatterProvider.IsRegistered<IWearable>())
        {
            IWearable_Formatter.AddToTag<CoreArmor>();
            IWearable_Formatter.AddToTag<Backpack>();
            FormatterProvider.Register(IWearable_Formatter);
            FormatterProvider.RegisterCollection<IWearable>();
        }

        // IStorage
        if (!FormatterProvider.IsRegistered<IStorage>())
        {
            IStorage_Formatter.AddToTag<Rig>();
            IStorage_Formatter.AddToTag<Backpack>();
            IStorage_Formatter.AddToTag<Stash>();
            FormatterProvider.Register(IStorage_Formatter);
            FormatterProvider.RegisterCollection<IStorage>();
        }
    }
}
