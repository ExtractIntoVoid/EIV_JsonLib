using EIV_Items.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EIV_Items.Json
{
    public static class ItemJsonInitilaizer
    {
        public static CustomPolymorphismRegistry<CoreItem> CoreItemPolymorphismRegistry { get; } = new() { Dicriminator = nameof(CoreItem.ItemType) };

        public static CustomPolymorphismRegistry<CoreArmor> CoreArmorPolymorphismRegistry { get; } = new() { Dicriminator = nameof(CoreItem.ItemType) };

        public static void Initialize()
        {
            JsonSerializerConvert.Polymorphisms.Add(CoreItemPolymorphismRegistry);
            JsonSerializerConvert.Polymorphisms.Add(CoreArmorPolymorphismRegistry);
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
        }
    }
}
