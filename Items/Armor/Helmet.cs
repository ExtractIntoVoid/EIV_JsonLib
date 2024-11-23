using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Helmet : ArmorBase
{
    public bool IsFullProtection { get; set; }
}
