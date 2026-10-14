using EIV_Items.Extensions;
using EIV_Pack;

namespace EIV_Profile.ProfileModules;

/// <summary>
/// Represesnt a simple readonly value module.
/// </summary>
/// <typeparam name="T">Any type.</typeparam>
[EIV_Packable]
public partial class ReadOnlyValueModule<T> : IProfileModule
{
    /// <inheritdoc/>
    public required string Name { get; init; }

    /// <inheritdoc/>
    public required string ModuleType { get; init; }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public required T Value { get; init; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Name: {Name}, T: {typeof(T).Name}, Val: {Value}";
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Name))
        {
            hash += HashCodeExtensions.Hash(Name);
        }

        if (Value != null)
        {
            hash += Value.GetHashCode();
        }

        return hash;
    }
}
