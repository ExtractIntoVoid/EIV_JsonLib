using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Throwable : UsableItemBase
{
    public decimal FuseTime { get; set; }
}
