using EIV_JsonLib.Interface;
using MemoryPack;

namespace EIV_JsonLib.Base;

/// <summary>
/// Represent an Abstract Core Armor.
/// </summary>
[MemoryPackable(GenerateType.NoGenerate)]
public abstract partial class CoreArmor : CoreItem, IWearable
{
    /// <summary>
    /// How much Precent it can block a Damagable Item.
    /// </summary>
    public decimal BlockEfficacy { get; set; }
    public string Slot { get; set; } = string.Empty;
}
