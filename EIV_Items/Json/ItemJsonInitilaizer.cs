using EIV_Items.Core;
using EIV_Items.Interfaces;

namespace EIV_Items.Json;

/// <summary>
/// Provides json polymorphism register.
/// </summary>
public static class ItemJsonInitilaizer
{
    /// <summary>
    /// Gets the <see cref="CoreItem"/> polymorphism registry.
    /// </summary>
    public static CustomPolymorphismRegistry<CoreItem> CoreItemPolymorphismRegistry { get; } = new() { Dicriminator = CoreItem.DiscriminatorName };

    /// <summary>
    /// Gets the <see cref="CoreArmor"/> polymorphism registry.
    /// </summary>
    public static CustomPolymorphismRegistry<CoreArmor> CoreArmorPolymorphismRegistry { get; } = new() { Dicriminator = CoreItem.DiscriminatorName };

    /// <summary>
    /// Gets the <see cref="CoreUsable"/> polymorphism registry.
    /// </summary>
    public static CustomPolymorphismRegistry<CoreUsable> CoreUsablePolymorphismRegistry { get; } = new() { Dicriminator = CoreItem.DiscriminatorName };

    /// <summary>
    /// Gets the <see cref="IDamageDealer"/> polymorphism registry.
    /// </summary>
    public static CustomPolymorphismRegistry<IDamageDealer> IDamageDealerPolymorphismRegistry { get; } = new() { Dicriminator = CoreItem.DiscriminatorName };

    /// <summary>
    /// Gets the <see cref="IDurable"/> polymorphism registry.
    /// </summary>
    public static CustomPolymorphismRegistry<IDurable> IDurablePolymorphismRegistry { get; } = new() { Dicriminator = CoreItem.DiscriminatorName };

    /// <summary>
    /// Gets the <see cref="IWearable"/> polymorphism registry.
    /// </summary>
    public static CustomPolymorphismRegistry<IWearable> IWearablePolymorphismRegistry { get; } = new() { Dicriminator = CoreItem.DiscriminatorName };

    /// <summary>
    /// Gets the <see cref="IStorage"/> polymorphism registry.
    /// </summary>
    public static CustomPolymorphismRegistry<IStorage> IStoragePolymorphismRegistry { get; } = new() { Dicriminator = CoreItem.DiscriminatorName };

    /// <summary>
    /// Initialize core polymorphisms and resolvers.
    /// </summary>
    public static void Initialize()
    {
        JsonSerializerConvert.Resolvers.Add(ItemSourceGenContext.Default);
        CoreItemPolymorphismRegistry.Register<Helmet>(nameof(Helmet));
        CoreItemPolymorphismRegistry.Register<Rig>(nameof(Rig));
        CoreItemPolymorphismRegistry.Register<Vest>(nameof(Vest));
        CoreItemPolymorphismRegistry.Register<Ammo>(nameof(Ammo));
        CoreItemPolymorphismRegistry.Register<ArmorPlate>(nameof(ArmorPlate));
        CoreItemPolymorphismRegistry.Register<Backpack>(nameof(Backpack));
        CoreItemPolymorphismRegistry.Register<GunMod>(nameof(GunMod));
        CoreItemPolymorphismRegistry.Register<Magazine>(nameof(Magazine));
        CoreItemPolymorphismRegistry.Register<Consumable>(nameof(Consumable));
        CoreItemPolymorphismRegistry.Register<Gun>(nameof(Gun));
        CoreItemPolymorphismRegistry.Register<Melee>(nameof(Melee));
        CoreItemPolymorphismRegistry.Register<Throwable>(nameof(Throwable));
        JsonSerializerConvert.Polymorphisms.Add(CoreItemPolymorphismRegistry);

        CoreArmorPolymorphismRegistry.Register<Helmet>(nameof(Helmet));
        CoreArmorPolymorphismRegistry.Register<Rig>(nameof(Rig));
        CoreArmorPolymorphismRegistry.Register<Vest>(nameof(Vest));
        JsonSerializerConvert.Polymorphisms.Add(CoreArmorPolymorphismRegistry);

        CoreUsablePolymorphismRegistry.Register<Consumable>(nameof(Consumable));
        CoreUsablePolymorphismRegistry.Register<Gun>(nameof(Gun));
        CoreUsablePolymorphismRegistry.Register<Melee>(nameof(Melee));
        CoreUsablePolymorphismRegistry.Register<Throwable>(nameof(Throwable));
        JsonSerializerConvert.Polymorphisms.Add(CoreUsablePolymorphismRegistry);

        IDamageDealerPolymorphismRegistry.Register<Ammo>(nameof(Ammo));
        IDamageDealerPolymorphismRegistry.Register<Melee>(nameof(Melee));
        JsonSerializerConvert.Polymorphisms.Add(IDamageDealerPolymorphismRegistry);

        IDurablePolymorphismRegistry.Register<ArmorPlate>(nameof(ArmorPlate));
        JsonSerializerConvert.Polymorphisms.Add(IDurablePolymorphismRegistry);

        IWearablePolymorphismRegistry.Register<Helmet>(nameof(Helmet));
        IWearablePolymorphismRegistry.Register<Rig>(nameof(Rig));
        IWearablePolymorphismRegistry.Register<Vest>(nameof(Vest));
        IWearablePolymorphismRegistry.Register<Backpack>(nameof(Backpack));
        JsonSerializerConvert.Polymorphisms.Add(IWearablePolymorphismRegistry);

        IStoragePolymorphismRegistry.Register<Rig>(nameof(Rig));
        IStoragePolymorphismRegistry.Register<Backpack>(nameof(Backpack));
        IStoragePolymorphismRegistry.Register<Stash>(nameof(Stash));
        JsonSerializerConvert.Polymorphisms.Add(IStoragePolymorphismRegistry);
    }
}
