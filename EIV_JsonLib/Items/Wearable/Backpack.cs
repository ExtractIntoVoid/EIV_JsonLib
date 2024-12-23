using EIV_JsonLib.Base;
using EIV_JsonLib.Interfaces;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Backpack : CoreItem, IWearable, IStorage
{
    public uint MaxSize { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal MaxVolume { get; set; }

    [MemoryPackAllowSerialize]
    public List<CoreItem> Items { get; set; } = [];
    public string Slot { get; set; } = string.Empty;

    public override int GetHashCode()
    {
        int hash = base.GetHashCode() + MaxSize.GetHashCode() + MaxWeight.GetHashCode() ^ MaxVolume.GetHashCode();
        if (Items.Count != 0)
            hash += (int)Items.Select(x => x.GetHashCode()).Average();
        if (!string.IsNullOrEmpty(Slot))
            hash += Slot.GetHashCode();
        return hash;
    }
}
