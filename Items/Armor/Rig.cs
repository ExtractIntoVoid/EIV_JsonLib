using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Rig : ArmorBase
{
    public List<string> ItemIds { get; set; } = [];
    public string? PlateSlotId { get; set; }
    public uint MaxItem { get; set; }
    public List<string> ItemTypesAccepted { get; set; } = [];
    public List<string> SpecificItemsAccepted { get; set; } = [];
    public List<string> ArmorPlateAccepted { get; set; } = [];
}
