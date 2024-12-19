using MemoryPack;
using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Base;

/// <summary>
/// Represent an Abstract Core Useble Item.
/// </summary>
[MemoryPackable(GenerateType.NoGenerate)]
public abstract partial class CoreUsable : CoreItem, IEquatable<CoreUsable>, IEqualityComparer<CoreUsable>
{
    /// <summary>
    /// Can we use the Item or not.
    /// </summary>
    public bool CanUse { get; set; }
    /// <summary>
    /// How long does it need to actually use this Item
    /// </summary>
    public decimal UseTime { get; set; }

    public bool Equals(CoreUsable? other)
    {
        if (other == null)
            return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    public bool Equals(CoreUsable? x, CoreUsable? y)
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
        return base.GetHashCode() + CanUse.GetHashCode() + UseTime.GetHashCode();
    }

    public int GetHashCode([DisallowNull] CoreUsable obj)
    {
        return obj.GetHashCode();
    }
}
