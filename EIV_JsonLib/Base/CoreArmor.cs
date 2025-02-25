using EIV_JsonLib.Interfaces;
using MemoryPack;
using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Base;

/// <summary>
/// Represent an Abstract Core Armor.
/// </summary>
[MemoryPackable(GenerateType.NoGenerate)]
public abstract partial class CoreArmor : CoreItem, IWearable, IEquatable<CoreArmor>, IEqualityComparer<CoreArmor>
{
    /// <summary>
    /// How much Precent it can block a Damagable Item.
    /// </summary>
    public decimal BlockEfficacy { get; set; }
    public string Slot { get; set; } = string.Empty;

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += BlockEfficacy.GetHashCode();
        if (!string.IsNullOrEmpty(Slot))
            hash += Slot.GetHashCode();
        return hash;
    }

    public bool Equals(CoreArmor? other)
    {
        if (other == null)
            return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    public bool Equals(CoreArmor? x, CoreArmor? y)
    {
        if (x == null && y == null)
            return true;
        if (x == null)
            return false;
        if (y == null)
            return false;
        return x.GetHashCode() == y.GetHashCode();
    }

    public int GetHashCode([DisallowNull] CoreArmor obj)
    {
        return obj.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as CoreArmor);
    }
}
