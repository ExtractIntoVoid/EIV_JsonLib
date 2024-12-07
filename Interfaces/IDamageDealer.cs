namespace EIV_JsonLib.Interface;

public interface IDamageDealer
{
    /// <summary>
    /// How much Damage does this Item do.
    /// </summary>
    public uint Damage { get; set; }
    /// <summary>
    /// How much Damage does this Item do to the Armor.
    /// </summary>
    public uint ArmorDamage { get; set; }
    /// <summary>
    /// The type of the Damage
    /// </summary>
    public string DamageType { get; set; }
}
