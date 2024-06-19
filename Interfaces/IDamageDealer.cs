namespace EIV_JsonLib.Interfaces;

// DONT FORMAT THIS, Only used in other Formatter!
public interface IDamageDealer : IItem
{
    public uint Damage { get; set; }
    public uint ArmorDamage { get; set; }
    public string DamageType { get; set; }
}
