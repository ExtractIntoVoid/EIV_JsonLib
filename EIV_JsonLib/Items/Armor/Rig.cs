using EIV_JsonLib.Base;
using EIV_JsonLib.Interfaces;
using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class Rig : CoreArmor, IStorage
{
    public uint MaxSize { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal MaxVolume { get; set; }
    public List<CoreItem> Items { get; set; } = [];
    public ArmorPlate? PlateSlot { get; set; }
    public List<string> ItemTypesAccepted { get; set; } = [];
    public List<string> SpecificItemsAccepted { get; set; } = [];
    public List<string> ArmorPlateAccepted { get; set; } = [];

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (Items.Count != 0)
            hash += (int)Items.Select(x => x.GetHashCode()).Average();
        if (PlateSlot != null)
            hash += PlateSlot.GetHashCode();
        hash += MaxSize.GetHashCode();
        hash += MaxWeight.GetHashCode();
        hash += MaxVolume.GetHashCode();
        if (Items.Count != 0)
            hash += (int)ItemTypesAccepted.Select(x => x.GetHashCode()).Average();
        if (Items.Count != 0)
            hash += (int)SpecificItemsAccepted.Select(x => x.GetHashCode()).Average();
        if (Items.Count != 0)
            hash += (int)ArmorPlateAccepted.Select(x => x.GetHashCode()).Average();
        return hash;
    }
}
