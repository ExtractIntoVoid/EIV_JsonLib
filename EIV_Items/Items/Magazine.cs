using EIV_Items.Core;
using EIV_Items.Extensions;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a gun magazine.
/// </summary>
[EIV_Packable]
public partial class Magazine : CoreItem, ICompatible
{
    /// <inheritdoc />
    public override string ItemType { get; init; } = nameof(Magazine);

    /// <summary>
    /// Gets the stored ammos.
    /// </summary>
    public Collection<Ammo> Ammunitions { get; init; } = [];

    /// <summary>
    /// Gets the max capacity of the <see cref="Ammunitions"/>.
    /// </summary>
    public uint MaxMagSize { get; init; }

    /// <summary>
    /// Gets the supported ammos.
    /// </summary>
    public Collection<string> SupportedAmmos { get; init; } = [];

    /// <inheritdoc />
    public bool IsCompatible(CoreItem item)
    {
        if (item is not Ammo ammo)
        {
            return false;
        }

        return SupportedAmmos.Contains(ammo.Id) || SupportedAmmos.Intersect(ammo.Tags).Any();
    }

    /// <summary>
    /// Trying to insert <paramref name="ammo"/> into this magazine.
    /// </summary>
    /// <param name="ammo">The ammos to insert.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public bool TryInsertAmmo(Ammo ammo)
    {
        // Magazine same as inside our mag, don't bother anything
        if (Ammunitions.Count == MaxMagSize)
        {
            return false;
        }

        if (!IsCompatible(ammo))
        {
            return false;
        }

        Ammunitions.Add(ammo);
        return true;
    }

    /// <summary>
    /// Trying to insert <paramref name="ammos"/> into this magazine.
    /// </summary>
    /// <param name="ammos">The ammos to insert.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public bool TryInsertAmmos(params Ammo[] ammos)
    {
        // Magazine same as inside our mag, don't bother anything
        if (Ammunitions.Count == MaxMagSize)
        {
            return false;
        }

        if (ammos == null)
        {
            return false;
        }

        foreach (var ammo in ammos)
        {
            if (!IsCompatible(ammo))
            {
                continue;
            }

            Ammunitions.Add(ammo);
            if (Ammunitions.Count == MaxMagSize)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Trying to insert <paramref name="ammo"/> into this magazine.
    /// </summary>
    /// <param name="ammo">The ammo to insert.</param>
    /// <param name="count">The count to insert with <paramref name="ammo"/>.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public bool TryInsertAmmos(Ammo ammo, int count)
    {
        // Magazine same as inside our mag, don't bother anything
        if (Ammunitions.Count == MaxMagSize)
        {
            return false;
        }

        if (ammo == null)
        {
            return false;
        }

        if (!IsCompatible(ammo))
        {
            return false;
        }

        for (int i = 0; i < count; i++)
        {
            Ammunitions.Add((Ammo)ammo.Clone());
            if (Ammunitions.Count == MaxMagSize)
            {
                return false;
            }
        }

        return true;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{base.ToString()} Ammos: ({string.Join(" ,", Ammunitions)}), MaxMagSize: {MaxMagSize}, SupportedAmmos: {string.Join(" ,", SupportedAmmos)}";
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (Ammunitions.Count != 0)
        {
            hash += (int)Ammunitions.Average(HashCodeExtensions.Hash);
        }

        hash += MaxMagSize.GetHashCode();
        if (SupportedAmmos.Count != 0)
        {
            hash += (int)SupportedAmmos.Average(HashCodeExtensions.StringHashFunction);
        }

        return hash;
    }
}
