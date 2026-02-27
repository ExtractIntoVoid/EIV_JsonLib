using EIV_JsonLib.Base;
using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class Throwable : CoreUsable
{
    public decimal FuseTime { get; set; }

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += FuseTime.GetHashCode();
        return hash;
    }
}
