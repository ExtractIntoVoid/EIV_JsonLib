using EIV_Items.Core;

namespace EIV_Items.Interfaces;

/// <summary>
/// Makes the item deal damage to others.
/// </summary>
public partial interface IDamageDealer
{
    /// <summary>
    /// Gets how much the item damages.
    /// </summary>
    public uint Damage { get; }

    /// <summary>
    /// Gets how much the item damages to the <see cref="CoreArmor"/>.
    /// </summary>
    public uint ArmorDamage { get; }

    /// <summary>
    /// Gets the type of the damage.
    /// </summary>
    public string DamageType { get; }
}
