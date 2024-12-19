using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class HealthEffect : BaseNPEffect
{
    public string Cause { get; set; } = string.Empty;
}
