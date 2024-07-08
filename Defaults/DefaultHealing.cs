using EIV_JsonLib.Classes;
using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultHealing : DefaultItem, IHealing
{
    public decimal HealAmount { get; set; }
    public List<SideEffect> SideEffects { get; set; } = [];
    public bool CanUse { get; set; }
    public decimal UseTime { get; set; }
    public override string ItemType { get; set; } = nameof(IHealing);

    public override string ToString()
    {
        return $"{base.ToString()} | {HealAmount} {SideEffects.Count} {CanUse} {UseTime}";
    }
}
