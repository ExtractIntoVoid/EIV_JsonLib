using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Stash
{
    public uint MaxSize { get; set; }
    public uint MaxWeight { get; set; }
    public decimal MaxVolume { get; set; }
    public List<ItemBase> Items { get; set; } = [];

    public override int GetHashCode()
    {
        return MaxSize.GetHashCode() + MaxWeight.GetHashCode() ^ MaxVolume.GetHashCode();
    }

    public override string ToString()
    {
        return $"MaxSize: {MaxSize}, MaxWeight: {MaxWeight}, MaxVolume: {MaxVolume}, Items: ({string.Join(" | ", Items)})";
    }
}
