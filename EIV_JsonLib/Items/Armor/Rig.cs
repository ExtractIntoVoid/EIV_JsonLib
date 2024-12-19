using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Rig : CoreArmor
{
    [MemoryPackAllowSerialize]
    public List<CoreItem> ItemIds { get; set; } = [];

    [MemoryPackAllowSerialize]
    public ArmorPlate? PlateSlot { get; set; }
    public uint MaxItem { get; set; }
    public List<string> ItemTypesAccepted { get; set; } = [];
    public List<string> SpecificItemsAccepted { get; set; } = [];
    public List<string> ArmorPlateAccepted { get; set; } = [];

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (ItemIds.Count != 0)
            hash += (int)ItemIds.Select(x => x.GetHashCode()).Average();
        if (PlateSlot != null)
            hash += PlateSlot.GetHashCode();
        hash += MaxItem.GetHashCode();
        if (ItemIds.Count != 0)
            hash += (int)ItemTypesAccepted.Select(x => x.GetHashCode()).Average();
        if (ItemIds.Count != 0)
            hash += (int)SpecificItemsAccepted.Select(x => x.GetHashCode()).Average();
        if (ItemIds.Count != 0)
            hash += (int)ArmorPlateAccepted.Select(x => x.GetHashCode()).Average();
        return hash;
    }
}
