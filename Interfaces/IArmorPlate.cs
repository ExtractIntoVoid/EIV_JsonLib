using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(ArmorPlateFormatter))]
public interface IArmorPlate : IDurable
{
    public string Material { get; set; }
}
