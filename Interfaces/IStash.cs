using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(StashFormatter))]
public interface IStash
{
    public uint MaxSize { get; set; }
    public uint MaxWeight { get; set; }
    public List<string> Items { get; set; }
}
