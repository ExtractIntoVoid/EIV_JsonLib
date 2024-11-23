using EIV_JsonLib.Base;
using EIV_JsonLib.Interface;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Ammo : ItemBase, IDamageDealer
{
    public decimal Speed { get; set; }
    public uint Damage { get; set; }
    public uint ArmorDamage { get; set; }
    public string DamageType { get; set; } = string.Empty;
}
