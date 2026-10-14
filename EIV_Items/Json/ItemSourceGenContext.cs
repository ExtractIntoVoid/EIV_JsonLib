using EIV_Items.Core;
using EIV_Items.Interfaces;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace EIV_Items.Json
{
    /// <summary>
    /// Repressent an item source generated context.
    /// </summary>
    [JsonSourceGenerationOptions]

    [JsonSerializable(typeof(Helmet))]
    [JsonSerializable(typeof(Rig))]
    [JsonSerializable(typeof(Vest))]
    [JsonSerializable(typeof(CoreArmor))]
    [JsonSerializable(typeof(CoreItem))]
    [JsonSerializable(typeof(CoreUsable))]
    [JsonSerializable(typeof(Ammo))]
    [JsonSerializable(typeof(ArmorPlate))]
    [JsonSerializable(typeof(Backpack))]
    [JsonSerializable(typeof(GunMod))]
    [JsonSerializable(typeof(Magazine))]
    [JsonSerializable(typeof(Consumable))]
    [JsonSerializable(typeof(Gun))]
    [JsonSerializable(typeof(Melee))]
    [JsonSerializable(typeof(Throwable))]

    [JsonSerializable(typeof(List<CoreItem>))]
    [JsonSerializable(typeof(Collection<CoreItem>))]

    [JsonSerializable(typeof(List<CoreUsable>))]
    [JsonSerializable(typeof(Collection<CoreUsable>))]

    [JsonSerializable(typeof(List<CoreArmor>))]
    [JsonSerializable(typeof(Collection<CoreArmor>))]

    [JsonSerializable(typeof(Stash))]

    [JsonSerializable(typeof(Collection<IWearable>))]
    public partial class ItemSourceGenContext : JsonSerializerContext
    {
    }
}
