using EIV_Items.Base;
using EIV_Items.Interfaces;
using EIV_Pack;

namespace EIV_Items;

[EIV_Packable]
public partial class Backpack : CoreItem, IWearable, IStorage
{
    public uint MaxSize { get; set; }
    public double MaxWeight { get; set; }
    public double MaxVolume { get; set; }
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
