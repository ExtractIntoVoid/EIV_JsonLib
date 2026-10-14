using EIV_Items.Extensions;
using EIV_Pack;

namespace EIV_Items;

/// <summary>
/// Represent a settings for giving effect when item being used.
/// </summary>
[EIV_Packable]
public partial class ItemEffectSettings
{
    /// <summary>
    /// Gets the name of the effect.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Gets the time to run the effect.
    /// </summary>
    public double Time { get; init; }

    /// <summary>
    /// Gets the strength of the effect.
    /// </summary>
    public int Strength { get; init; }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (!string.IsNullOrEmpty(Name))
        {
            hash += HashCodeExtensions.Hash(Name);
        }

        hash += Time.GetHashCode();
        hash += Strength.GetHashCode();
        return hash;
    }
}
