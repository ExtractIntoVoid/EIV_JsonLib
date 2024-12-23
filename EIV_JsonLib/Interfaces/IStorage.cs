using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib.Interfaces;

[MemoryPackable(GenerateType.NoGenerate)]
public partial interface IStorage
{
    public uint MaxSize { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal MaxVolume { get; set; }

    [MemoryPackAllowSerialize]
    public List<CoreItem> Items { get; set; }
}
