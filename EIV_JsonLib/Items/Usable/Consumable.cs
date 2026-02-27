using EIV_JsonLib.Base;
using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class Consumable : CoreUsable
{
    public uint MaxUses { get; set; }
    public int EnergyRestore { get; set; }
    public int HydrationRestore { get; set; }
    public List<SideEffect> SideEffects { get; set; } = [];

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += MaxUses.GetHashCode();
        hash += EnergyRestore.GetHashCode();
        hash += HydrationRestore.GetHashCode();
        if (SideEffects.Count != 0)
            hash += (int)SideEffects.Select(x => x.GetHashCode()).Average();
        return hash;
    }
}
