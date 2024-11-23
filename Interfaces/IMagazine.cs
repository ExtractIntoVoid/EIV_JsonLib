using EIV_JsonLib.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(MagazineFormatter))]
public interface IMagazine : IItem
{
    public List<string> Ammunition { get; set; }
    public uint MaxMagSize { get; set; }
    public List<string> SupportedAmmo { get; set; }
}
