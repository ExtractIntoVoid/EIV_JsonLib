using EIV_Items;
using EIV_Items.Extensions;
using EIV_Pack;
using System.Collections.ObjectModel;

namespace EIV_Profile.ProfileModules;

/// <summary>
/// Represent a status effect module.
/// </summary>
[EIV_Packable]
public partial class StatusEffectModule : IProfileModule
{
    /// <inheritdoc/>
    public required string Name { get; init; }

    /// <inheritdoc/>
    public string ModuleType { get; init; } = nameof(StatusEffectModule);

    /// <summary>
    /// Gets the effects.
    /// </summary>
    public Collection<ItemEffectSettings> Effects { get; init; } = [];

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Name: {Name}, Effects: ({string.Join("| ", Effects)})";
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Name))
        {
            hash += HashCodeExtensions.Hash(Name);
        }

        if (Effects.Count != 0)
        {
            hash += (int)Effects.Average(x => x.GetHashCode());
        }

        return hash;
    }
}
