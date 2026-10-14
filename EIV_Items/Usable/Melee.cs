using EIV_Items.Core;
using EIV_Items.Extensions;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a melee item.
/// </summary>
[EIV_Packable]
public partial class Melee : CoreUsable, IDamageDealer
{
    /// <inheritdoc />
    public override string ItemType { get; init; } = nameof(Melee);

    /// <inheritdoc/>
    public uint Damage { get; set; }

    /// <inheritdoc/>
    public uint ArmorDamage { get; set; }

    /// <inheritdoc/>
    public string DamageType { get; set; } = string.Empty;

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += Damage.GetHashCode();
        hash += ArmorDamage.GetHashCode();
        if (!string.IsNullOrEmpty(DamageType))
        {
            hash += HashCodeExtensions.Hash(DamageType);
        }

        return hash;
    }
}
