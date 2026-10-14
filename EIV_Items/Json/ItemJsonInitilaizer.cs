using EIV_Items.Core;

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
    public static CustomPolymorphismRegistry<CoreUsable> CoreUsableolymorphismRegistry { get; } = new() { Dicriminator = CoreItem.DiscriminatorName };

    /// <summary>
    /// Initialize core polymorphisms and resolvers.
    /// </summary>
    public static void Initialize()
    {
        JsonSerializerConvert.Polymorphisms.Add(CoreItemPolymorphismRegistry);
        JsonSerializerConvert.Polymorphisms.Add(CoreArmorPolymorphismRegistry);
        JsonSerializerConvert.Polymorphisms.Add(CoreUsableolymorphismRegistry);
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
        CoreArmorPolymorphismRegistry.Register<Helmet>(nameof(Helmet));
        CoreArmorPolymorphismRegistry.Register<Rig>(nameof(Rig));
        CoreArmorPolymorphismRegistry.Register<Vest>(nameof(Vest));
        CoreUsableolymorphismRegistry.Register<Consumable>(nameof(Consumable));
        CoreUsableolymorphismRegistry.Register<Gun>(nameof(Gun));
        CoreUsableolymorphismRegistry.Register<Melee>(nameof(Melee));
        CoreUsableolymorphismRegistry.Register<Throwable>(nameof(Throwable));
    }
}
