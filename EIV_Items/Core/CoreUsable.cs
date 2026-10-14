using EIV_Pack;
using EIV_Pack.Formatters;
using System.Diagnostics.CodeAnalysis;

namespace EIV_Items.Core;

/// <summary>
/// Represent an Usable Item.
/// </summary>
public abstract partial class CoreUsable : CoreItem, IPackable<CoreUsable>, IEquatable<CoreUsable>, IEqualityComparer<CoreUsable>
{
#if NET8_0_OR_GREATER
    /// <inheritdoc/>
    public static void SerializePackable(ref PackWriter writer, scoped ref readonly CoreUsable? value)
    {
        FormatterInitializer.CoreUsable_Formatter.Serialize(ref writer, in value);
    }

    /// <inheritdoc/>
    public static void DeserializePackable(ref PackReader reader, scoped ref CoreUsable? value)
    {
        FormatterInitializer.CoreUsable_Formatter.Deserialize(ref reader, ref value);
    }
#endif

    /// <summary>
    /// Gets a value indicating whether can we use the item.
    /// </summary>
    public bool CanUse { get; init; }

    /// <summary>
    /// Gets how long does it need to actually use this Item.
    /// </summary>
    public double UseTime { get; init; }

    /// <inheritdoc/>
    public bool Equals(CoreUsable? other)
    {
        if (other == null)
        {
            return false;
        }

        return GetHashCode() == other.GetHashCode();
    }

    /// <inheritdoc/>
    public bool Equals(CoreUsable? x, CoreUsable? y)
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
        return base.GetHashCode() + CanUse.GetHashCode() + UseTime.GetHashCode();
    }

    /// <inheritdoc/>
    public int GetHashCode([DisallowNull] CoreUsable obj)
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
        return Equals(obj as CoreUsable);
    }
}
