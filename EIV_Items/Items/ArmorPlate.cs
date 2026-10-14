using EIV_Items.Core;
using EIV_Items.Extensions;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent an armor plate.
/// </summary>
[EIV_Packable]
public partial class ArmorPlate : CoreItem, IDurable
{
    /// <inheritdoc />
    public override string ItemType { get; init; } = nameof(ArmorPlate);

    /// <summary>
    /// Gets the material type this plate made of.
    /// </summary>
    public string Material { get; init; } = string.Empty;

    /// <inheritdoc/>
    public uint Durability { get; init; }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (!string.IsNullOrEmpty(Material))
        {
            hash += HashCodeExtensions.Hash(Material);
        }

        hash += Durability.GetHashCode();
        return hash;
    }
}
