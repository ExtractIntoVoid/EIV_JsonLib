using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Base;

/// <summary>
/// Represent an Abstract Core Useble Item.
/// </summary>
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

    /// <inheritdoc/>
    public bool Equals(CoreUsable? other)
    {
        if (other == null)
            return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return base.GetHashCode() + CanUse.GetHashCode() + UseTime.GetHashCode();
    }

    /// <inheritdoc/>
    public int GetHashCode(
#if NET8_0_OR_GREATER
        [DisallowNull]
#endif
        CoreUsable obj)
    {
        return obj.GetHashCode();
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as CoreUsable);
    }
}
