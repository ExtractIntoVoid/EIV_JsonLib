using EIV_JsonLib.Base;
using EIV_JsonLib.Interfaces;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class ArmorPlate : CoreItem, IDurable
{
    public string Material { get; set; } = string.Empty;
    public uint Durability { get; set; }

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (!string.IsNullOrEmpty(Material))
            hash += Material.GetHashCode();
        hash += Durability.GetHashCode();
        return hash;
    }
}
