using EIV_Items.Base;
using EIV_Items.Interfaces;
using EIV_Pack;

namespace EIV_Items;

[EIV_Packable]
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
