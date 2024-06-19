using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.DefaultItems;

public class DefaultStash : IStash
{
    public uint MaxSize { get; set; }
    public uint MaxWeight { get; set; }
    public List<string> Items { get; set; } = [];
}
