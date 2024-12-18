using EIV_JsonLib.Interfaces;
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

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += BlockEfficacy.GetHashCode();
        if (!string.IsNullOrEmpty(Slot))
            hash += Slot.GetHashCode();
        return hash;
    }
}
