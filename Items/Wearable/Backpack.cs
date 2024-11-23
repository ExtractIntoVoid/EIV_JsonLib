using EIV_JsonLib.Base;
using EIV_JsonLib.Interface;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Backpack : ItemBase, IWearable
{
    [MemoryPackIgnore]
    public decimal CurrentWeight { get; set; }
    public decimal MaxItemWeight { get; set; }
    public decimal MaxItemVolume { get; set; }
    public List<ItemBase> Items { get; set; } = [];
    public string Slot { get; set; } = string.Empty;
}
