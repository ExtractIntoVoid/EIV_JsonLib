using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultAmmo : DefaultItem, IAmmo
{
    public uint Damage { get; set; }
    public uint ArmorDamage { get; set; }
    public string DamageType { get; set; } = string.Empty;
    public decimal Speed { get; set; }
    public override string ItemType { get; set; } = nameof(IAmmo);

    public override string ToString()
    {
        return $"{base.ToString()} | {Damage} {ArmorDamage} {DamageType} {Speed}";
    }
}
