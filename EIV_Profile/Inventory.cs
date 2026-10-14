using EIV_Items.Core;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace EIV_Profile;

/// <summary>
/// Represent a player inventory.
/// </summary>
[EIV_Packable]
public partial class Inventory : IEquatable<Inventory>, IEqualityComparer<Inventory>
{
    /// <summary>
    /// Gets or sets current item being held.
    /// </summary>
    public CoreItem? Hand { get; set; }

    /// <summary>
    /// Gets the wearables the character have.
    /// </summary>
    public Collection<IWearable> Wearables { get; init; } = [];

    /// <summary>
    /// Gets the <see cref="CoreItem"/>'s that can be equiped fast.
    /// </summary>
    public Collection<CoreUsable> ToolBelt { get; init; } = [];

    /// <inheritdoc/>
    public bool Equals(Inventory? other)
    {
        if (other == null)
        {
            return false;
        }

        return other.GetHashCode() == this.GetHashCode();
    }

    /// <inheritdoc/>
    public bool Equals(Inventory? x, Inventory? y)
    {
        if (x == null && y == null)
        {
            return true;
        }

        if (x == null)
        {
            return false;
        }

        if (y == null)
        {
            return false;
        }

        return x.GetHashCode() == y.GetHashCode();
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = 0;
        if (Hand != null)
        {
            hash += Hand.GetHashCode();
        }

        if (Wearables.Count != 0)
        {
            hash += (int)Wearables.Average(x => x.GetHashCode());
        }

        if (ToolBelt.Count != 0)
        {
            hash += (int)ToolBelt.Average(x => x.GetHashCode());
        }

        return hash;
    }

    /// <inheritdoc/>
    public int GetHashCode([DisallowNull] Inventory obj)
    {
        if (obj == null)
        {
            return 0;
        }

        return obj.GetHashCode();
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as Inventory);
    }
}
