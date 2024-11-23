using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Consumable : UsableItemBase
{
    public uint MaxUses { get; set; }
    public int EnergyRestore { get; set; }
    public int HydrationRestore { get; set; }
    public List<SideEffect> SideEffects { get; set; } = [];
}
