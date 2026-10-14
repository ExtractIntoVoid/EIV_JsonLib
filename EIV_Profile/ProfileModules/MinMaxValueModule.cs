using EIV_Pack;

namespace EIV_Profile.ProfileModules;

/// <summary>
/// Represent a min, max, value module.
/// </summary>
/// <typeparam name="T">Any type.</typeparam>
[EIV_Packable]
public partial class MinMaxValueModule<T> : ValueModule<T>, IProfileModule
{
    /// <summary>
    /// Gets the minimum value.
    /// </summary>
    public required T MinValue { get; init; }

    /// <summary>
    /// Gets the maximum value.
    /// </summary>
    public required T MaxValue { get; init; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Name: {Name}, T: {typeof(T).Name}, Min: {MinValue}, Max: {MaxValue}, Val: {Value}";
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (MinValue != null)
        {
            hash += MinValue.GetHashCode();
        }

        if (MaxValue != null)
        {
            hash += MaxValue.GetHashCode();
        }

        return hash;
    }
}
