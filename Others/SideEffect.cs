using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class SideEffect
{
    public string EffectName { get; set; } = string.Empty;
    public int EffectTime { get; set; }
    public int EffectStrength { get; set; }
}
