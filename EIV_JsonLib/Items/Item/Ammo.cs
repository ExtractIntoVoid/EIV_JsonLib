﻿using EIV_JsonLib.Base;
using EIV_JsonLib.Interfaces;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Ammo : CoreItem, IDamageDealer
{
    public decimal Speed { get; set; }
    public uint Damage { get; set; }
    public uint ArmorDamage { get; set; }
    public string DamageType { get; set; } = string.Empty;

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += Speed.GetHashCode();
        hash += Damage.GetHashCode();
        hash += ArmorDamage.GetHashCode();
        if (!string.IsNullOrEmpty(DamageType))
            hash += DamageType.GetHashCode();
        return hash;
    }
}
