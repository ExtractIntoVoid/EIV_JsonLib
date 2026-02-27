using EIV_JsonLib.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Base;

/// <summary>
/// Represent a Core Armor.
/// </summary>
public abstract partial class CoreArmor : CoreItem, IWearable, IEquatable<CoreArmor>, IEqualityComparer<CoreArmor>
{
    /// <summary>
    /// How much Precent it can block a Damagable Item.
    /// </summary>
    public decimal BlockEfficacy { get; set; }

    /// <inheritdoc/>
    public string Slot { get; set; } = string.Empty;

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += BlockEfficacy.GetHashCode();
        if (!string.IsNullOrEmpty(Slot))
            hash += Slot.GetHashCode();
        return hash;
    }

    /// <inheritdoc/>
    public bool Equals(CoreArmor? other)
    {
        if (other == null)
            return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public int GetHashCode(
#if NET8_0_OR_GREATER
        [DisallowNull]
#endif
        CoreArmor obj)
    {
        return obj.GetHashCode();
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as CoreArmor);
    }
}
