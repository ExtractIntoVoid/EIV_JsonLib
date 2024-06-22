using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultRig : DefaultItem, IRig
{
    public override string ItemType { get; set; } = nameof(IRig);
    public uint MaxItem { get; set; }
    public List<string> ItemTypesAccepted { get; set; } = [];
    public List<string> SpecificItemsAccepted { get; set; } = [];
    public List<string> ArmorPlateAccepted { get; set; } = [];
    public List<string> ItemIds { get; set; } = [];
    public string? PlateSlotId { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()} | {MaxItem} {ItemTypesAccepted.Count} {SpecificItemsAccepted.Count} {ArmorPlateAccepted.Count} {ItemIds.Count} {PlateSlotId == null}";
    }
}
