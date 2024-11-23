using EIV_JsonLib.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(RigFormatter))]
public interface IRig : IItem
{
    public List<string> ItemIds { get; set; }
    public string? PlateSlotId { get; set; }
    public uint MaxItem { get; set; }
    public List<string> ItemTypesAccepted { get; set; }
    public List<string> SpecificItemsAccepted { get; set; }
    public List<string> ArmorPlateAccepted { get; set; }
}
