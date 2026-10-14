using EIV_Items.Base;
using EIV_Items.Interfaces;
using EIV_Pack;

namespace EIV_Items;

[EIV_Packable]
public partial class Melee : CoreUsable, IDamageDealer
{
    public uint Damage { get; set; }
    public uint ArmorDamage { get; set; }
    public string DamageType { get; set; } = string.Empty;

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += Damage.GetHashCode();
        hash += ArmorDamage.GetHashCode();
        if (!string.IsNullOrEmpty(DamageType))
            hash += DamageType.GetHashCode();
        return hash;
    }
}
