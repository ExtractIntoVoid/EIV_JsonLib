using EIV_Items.Base;
using EIV_Pack;

namespace EIV_Items;

[EIV_Packable]
public partial class Throwable : CoreUsable
{
    public double FuseTime { get; set; }

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += FuseTime.GetHashCode();
        return hash;
    }
}
