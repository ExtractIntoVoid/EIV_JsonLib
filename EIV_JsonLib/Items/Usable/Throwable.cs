using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
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
