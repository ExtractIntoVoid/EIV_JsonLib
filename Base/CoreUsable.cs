using MemoryPack;

namespace EIV_JsonLib.Base;

/// <summary>
/// Represent an Abstract Core Useble Item.
/// </summary>
[MemoryPackable(GenerateType.NoGenerate)]
public abstract partial class CoreUsable : CoreItem
{
    /// <summary>
    /// Can we use the Item or not.
    /// </summary>
    public bool CanUse { get; set; }
    /// <summary>
    /// How long does it need to actually use this Item
    /// </summary>
    public decimal UseTime { get; set; }

    public override int GetHashCode()
    {
        return base.GetHashCode() + CanUse.GetHashCode() + UseTime.GetHashCode();
    }
}
