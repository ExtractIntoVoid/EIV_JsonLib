using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class BaseNPEffect
{
    public int Negative { get; set; }
    public int Positive { get; set; }
}
