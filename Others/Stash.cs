using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Stash
{
    public uint MaxSize { get; set; }
    public uint MaxWeight { get; set; }
    public decimal MaxVolume { get; set; }
    public List<string> Items { get; set; } = [];
}
