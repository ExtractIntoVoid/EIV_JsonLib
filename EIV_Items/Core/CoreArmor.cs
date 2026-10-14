using EIV_Items.Extensions;
using EIV_Items.Interfaces;
using EIV_Pack;
using EIV_Pack.Formatters;
using System.Diagnostics.CodeAnalysis;

namespace EIV_Items.Core;

/// <summary>
/// Represent a Core Armor.
/// </summary>
public abstract partial class CoreArmor : CoreItem, IWearable, IPackable<CoreArmor>, IEquatable<CoreArmor>, IEqualityComparer<CoreArmor>
{
#if NET8_0_OR_GREATER
    /// <inheritdoc/>
    public static void SerializePackable(ref PackWriter writer, scoped ref readonly CoreArmor? value)
    {
        FormatterInitializer.CoreArmor_Formatter.Serialize(ref writer, in value);
    }

    /// <inheritdoc/>
    public static void DeserializePackable(ref PackReader reader, scoped ref CoreArmor? value)
    {
        FormatterInitializer.CoreArmor_Formatter.Deserialize(ref reader, ref value);
    }
#endif

    /// <summary>
    /// Gets how much precent it can block a <see cref="IDamageDealer"/> item.
    /// </summary>
    public double BlockEfficacy { get; init; }

    /// <inheritdoc/>
    public string Slot { get; init; } = string.Empty;

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += BlockEfficacy.GetHashCode();
        if (!string.IsNullOrEmpty(Slot))
        {
            hash += HashCodeExtensions.Hash(Slot);
        }

        return hash;
    }

    /// <inheritdoc/>
    public bool Equals(CoreArmor? other)
    {
        if (other == null)
        {
            return false;
        }

        return GetHashCode() == other.GetHashCode();
    }

    /// <inheritdoc/>
    public bool Equals(CoreArmor? x, CoreArmor? y)
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
    public int GetHashCode([DisallowNull] CoreArmor obj)
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
        return Equals(obj as CoreArmor);
    }
}
