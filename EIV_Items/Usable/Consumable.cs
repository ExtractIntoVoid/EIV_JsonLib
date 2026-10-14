using EIV_Items.Core;
using EIV_Pack;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a consumable item.
/// </summary>
[EIV_Packable]
public partial class Consumable : CoreUsable
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string ItemType { get; init; } = nameof(Consumable);

    /// <summary>
    /// Gets the how much this consumable can be used.
    /// </summary>
    public uint MaxUses { get; init; }

    /// <summary>
    /// Gets what modules to restore with the value.
    /// </summary>
    public Dictionary<string, int> RestoreModules { get; init; } = [];

    /// <summary>
    /// Gets the side effect this consumable gives.
    /// </summary>
    public Collection<ItemEffectSettings> SideEffects { get; init; } = [];

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += MaxUses.GetHashCode();
        hash += RestoreModules.GetHashCode();
        if (SideEffects.Count != 0)
        {
            hash += (int)SideEffects.Average(x => x.GetHashCode());
        }

        return hash;
    }
}
