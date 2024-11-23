using MemoryPack;

namespace EIV_JsonLib.Base;

[MemoryPackable(GenerateType.NoGenerate)]
public abstract partial class UsableItemBase : ItemBase
{
    [MemoryPackIgnore]
    public bool CanUse { get; set; }
    public decimal UseTime { get; set; }
}
