using EIV_JsonLib.Base;
using EIV_JsonLib.Interfaces;
using MemoryPack;
using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Profile;

[MemoryPackable]
public partial class Inventory : IEquatable<Inventory>, IEqualityComparer<Inventory>
{
    /// <summary>
    /// Hands, the Current Item being held.
    /// </summary>
    [MemoryPackAllowSerialize]
    public CoreItem? Hand { get; set; }

    /// <summary>
    /// Armors
    /// </summary>
    [MemoryPackAllowSerialize]
    public List<IWearable> Wearables { get; set; } = [];

    /// <summary>
    /// <see cref="CoreItem"/>'s that can be equiped fast. [Melee, Guns, etc]
    /// </summary>
    [MemoryPackAllowSerialize]
    public List<CoreUsable> ToolBelt { get; set; } = [];

    public bool Equals(Inventory? other)
    {
        if (other == null)
            return false;
        return other.GetHashCode() == this.GetHashCode();
    }

    public bool Equals(Inventory? x, Inventory? y)
    {
        if (x == null && y == null)
            return true;
        if (x == null)
            return false;
        if (y == null)
            return false;
        return x.GetHashCode() == y.GetHashCode();
    }

    public override int GetHashCode()
    {
        int hash = 0;
        if (Hand != null)
            hash += Hand.GetHashCode();
        if (Wearables.Count != 0)
            hash += (int)Wearables.Select(x => x.GetHashCode()).Average();
        if (ToolBelt.Count != 0)
            hash += (int)ToolBelt.Select(x => x.GetHashCode()).Average();
        return hash;
    }

    public int GetHashCode([DisallowNull] Inventory obj)
    {
        if (obj == null)
            return 0;
        return obj.GetHashCode();
    }
}
