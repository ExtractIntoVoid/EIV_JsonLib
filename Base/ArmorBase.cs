using EIV_JsonLib.Interface;
using MemoryPack;

namespace EIV_JsonLib.Base;

[MemoryPackable(GenerateType.NoGenerate)]
public abstract partial class ArmorBase : ItemBase, IWearable
{
    public decimal BlockEfficacy { get; set; }
    public decimal ArmorWeight { get; set; }
    public string Slot { get; set; } = string.Empty;
}
