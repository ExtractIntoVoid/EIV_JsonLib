using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Helmet : CoreArmor
{
    public bool IsFullProtection { get; set; }
}
