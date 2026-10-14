using EIV_Items.Core;
using EIV_Items.Extensions;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a vest armor.
/// </summary>
[EIV_Packable]
public partial class Rig : CoreArmor, IStorage, ICompatible
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string ItemType { get; init; } = nameof(Rig);

    /// <inheritdoc/>
    public uint MaxSize { get; init; }

    /// <inheritdoc/>
    public double MaxWeight { get; init; }

    /// <inheritdoc/>
    public double MaxVolume { get; init; }

    /// <inheritdoc/>
    public Collection<CoreItem> Items { get; init; } = [];

    /// <summary>
    /// Gets the armor plate.
    /// </summary>
    public ArmorPlate? PlateSlot { get; private set; }

    /// <summary>
    /// Gets the items accepted into <see cref="Items"/>.
    /// </summary>
    public Collection<string> ItemAccepted { get; init; } = [];

    /// <summary>
    /// Gets the item tags accepted into <see cref="Items"/>.
    /// </summary>
    public Collection<string> ItemTagsAccepted { get; init; } = [];

    /// <summary>
    /// Gets the armor plate ids accepted into <see cref="PlateSlot"/>.
    /// </summary>
    public Collection<string> ArmorPlateAccepted { get; init; } = [];

    /// <summary>
    /// Checks whenever the <paramref name="armorPlateId"/> is compatible with this rig.
    /// </summary>
    /// <param name="armorPlateId">The id of the armor plate.</param>
    /// <returns><see langword="true"/> if compatible; otherwise <see langword="false"/>.</returns>
    public bool CheckCompatibleArmorPlate(string armorPlateId)
    {
        return ICompatibleExtensions.CommpatibleIfEmpty(ArmorPlateAccepted, armorPlateId);
    }

    /// <summary>
    /// Checks whenever the <paramref name="item"/> is can be stored in this rig.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns><see langword="true"/> if compatible; otherwise <see langword="false"/>.</returns>
    public bool CheckCompatibleItem(CoreItem item)
    {
        if (item == null)
        {
            return false;
        }

        return ICompatibleExtensions.CommpatibleIfEmpty(ItemAccepted, item.Id) || ICompatibleExtensions.CompatibleTag(ItemTagsAccepted, item);
    }

    /// <inheritdoc/>
    public bool IsCompatible(CoreItem item)
    {
        if (item == null)
        {
            return false;
        }

        if (item is ArmorPlate)
        {
            return CheckCompatibleArmorPlate(item.Id);
        }

        return CheckCompatibleItem(item);
    }

    /// <summary>
    /// Tries to set <paramref name="armorPlate"/>.
    /// </summary>
    /// <param name="armorPlate">The armor plate.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public bool TrySetArmorPlate(ArmorPlate armorPlate)
    {
        if (armorPlate == null)
        {
            return false;
        }

        if (!CheckCompatibleArmorPlate(armorPlate.Id))
        {
            return false;
        }

        PlateSlot = armorPlate;
        return true;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (Items.Count != 0)
        {
            hash += (int)Items.Average(HashCodeExtensions.Hash);
        }

        if (PlateSlot != null)
        {
            hash += PlateSlot.GetHashCode();
        }

        hash += MaxSize.GetHashCode();
        hash += MaxWeight.GetHashCode();
        hash += MaxVolume.GetHashCode();

        if (ItemAccepted.Count != 0)
        {
            hash += (int)ItemAccepted.Average(HashCodeExtensions.StringHashFunction);
        }

        if (ItemTagsAccepted.Count != 0)
        {
            hash += (int)ItemTagsAccepted.Average(HashCodeExtensions.StringHashFunction);
        }

        if (ArmorPlateAccepted.Count != 0)
        {
            hash += (int)ArmorPlateAccepted.Average(HashCodeExtensions.StringHashFunction);
        }

        return hash;
    }
}
