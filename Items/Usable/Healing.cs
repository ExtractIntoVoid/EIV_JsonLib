using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Healing : CoreUsable
{
    public int HealAmount { get; set; }
    [MemoryPackAllowSerialize]
    public List<SideEffect> SideEffects { get; set; } = [];
}
