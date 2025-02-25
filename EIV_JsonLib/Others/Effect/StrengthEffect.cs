using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class StrengthEffect
{
    public int Min { get; set; }
    public int Max { get; set; }
    public List<string> ApplyTo { get; set; } = [];
}
