using EIV_JsonLib.Base;
using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class Healing : CoreUsable
{
    public int HealAmount { get; set; }
    public List<SideEffect> SideEffects { get; set; } = [];

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += HealAmount.GetHashCode();
        if (SideEffects.Count != 0)
            hash += (int)SideEffects.Select(x => x.GetHashCode()).Average();
        return hash;
    }
}
