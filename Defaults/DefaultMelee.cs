using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultMelee : DefaultItem, IMelee
{
    public bool CanUse { get; set; }
    public decimal UseTime { get; set; }
    public override string ItemType { get; set; } = nameof(IMelee);
    public uint Damage { get; set; }
    public uint ArmorDamage { get; set; }
    public string DamageType { get; set; } = string.Empty;
    public override string ToString()
    {
        return $"{base.ToString()} | {CanUse} {UseTime} {Damage} {ArmorDamage} {DamageType}";
    }
}
