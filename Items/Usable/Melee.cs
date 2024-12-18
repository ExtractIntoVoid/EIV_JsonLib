using EIV_JsonLib.Base;
using EIV_JsonLib.Interfaces;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Melee : CoreUsable, IDamageDealer
{
    public uint Damage { get; set; }
    public uint ArmorDamage { get; set; }
    public string DamageType { get; set; } = string.Empty;
}
