using EIV_Items.Core;
using EIV_Items.Extensions;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a wearable backpack.
/// </summary>
[EIV_Packable]
public partial class Backpack : CoreItem, IWearable, IStorage
{
    /// <inheritdoc />
    public override string ItemType { get; init; } = nameof(Backpack);

    /// <inheritdoc />
    public uint MaxSize { get; set; }

    /// <inheritdoc />
    public double MaxWeight { get; set; }

    /// <inheritdoc />
    public double MaxVolume { get; set; }

    /// <inheritdoc />
    public Collection<CoreItem> Items { get; set; } = [];

    /// <inheritdoc />
    public string Slot { get; set; } = string.Empty;

    /// <inheritdoc />
    public override int GetHashCode()
    {
        int hash = base.GetHashCode() + MaxSize.GetHashCode() + MaxWeight.GetHashCode() ^ MaxVolume.GetHashCode();
        if (Items.Count != 0)
        {
            hash += (int)Items.Average(HashCodeExtensions.Hash);
        }

        if (!string.IsNullOrEmpty(Slot))
        {
            hash += HashCodeExtensions.Hash(Slot);
        }

        return hash;
    }
}
