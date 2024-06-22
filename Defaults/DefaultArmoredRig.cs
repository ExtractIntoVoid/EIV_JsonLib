using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultArmoredRig : DefaultItem, IArmoredRig
{
    public decimal BlockEfficacy { get; set; }
    public decimal ArmorWeight { get; set; }
    public override string ItemType { get; set; } = nameof(IArmoredRig);
    public uint MaxItem { get; set; }
    public List<string> ItemTypesAccepted { get; set; } = [];
    public List<string> SpecificItemsAccepted { get; set; } = [];
    public List<string> ArmorPlateAccepted { get; set; } = [];
    public List<string> ItemIds { get; set; } = [];
    public string? PlateSlotId { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()} | {BlockEfficacy} {ArmorWeight} | {MaxItem} {ItemTypesAccepted.Count} {SpecificItemsAccepted.Count} {ArmorPlateAccepted.Count} {ItemIds.Count} {PlateSlotId == null}";
    }
}
