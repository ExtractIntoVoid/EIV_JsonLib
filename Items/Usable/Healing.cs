using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Healing : UsableItemBase
{
    public int HealAmount { get; set; }
    public List<SideEffect> SideEffects { get; set; } = [];
}
