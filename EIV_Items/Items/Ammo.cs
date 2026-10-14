using EIV_Items.Core;
using EIV_Items.Extensions;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent an ammo item.
/// </summary>
[EIV_Packable]
public partial class Ammo : CoreItem, IDamageDealer
{
    /// <inheritdoc />
    public override string ItemType { get; init; } = nameof(Ammo);

    /// <summary>
    /// Gets a value indicating whether the ammo should use raycasting or physical bullet.
    /// </summary>
    public bool UseRaycast { get; init; }

    /// <summary>
    /// Gets the speed of the ammo.
    /// </summary>
    public double Speed { get; init; }

    /// <inheritdoc />
    public uint Damage { get; init; }

    /// <inheritdoc />
    public uint ArmorDamage { get; init; }

    /// <inheritdoc />
    public string DamageType { get; init; } = string.Empty;

    /// <inheritdoc />
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += UseRaycast.GetHashCode();
        hash += Speed.GetHashCode();
        hash += Damage.GetHashCode();
        hash += ArmorDamage.GetHashCode();
        if (!string.IsNullOrEmpty(DamageType))
        {
            hash += HashCodeExtensions.Hash(DamageType);
        }

        return hash;
    }
}
