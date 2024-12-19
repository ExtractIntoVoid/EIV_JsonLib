using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Helmet : CoreArmor
{
    public bool IsFullProtection { get; set; }

    public override int GetHashCode()
    {
        return base.GetHashCode() + IsFullProtection.GetHashCode();
    }
}
