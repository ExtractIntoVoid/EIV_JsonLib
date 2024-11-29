using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Inventory
{
    public ItemBase? Hand { get; set; }
    public List<ItemBase> Items { get; set; } = [];
    public Gun? Primary { get; set; }
    public Gun? Secondary { get; set; }
    public Melee? MeleeSlot { get; set; }
    public Backpack? Backpack { get; set; }
    public List<ArmorBase> Armors { get; set; } = [];
}
