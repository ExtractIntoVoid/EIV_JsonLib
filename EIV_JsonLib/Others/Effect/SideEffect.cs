using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class SideEffect
{
    public string EffectName { get; set; } = string.Empty;
    public int EffectTime { get; set; }
    public int EffectStrength { get; set; }

    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(EffectName))
            hash += EffectName.GetHashCode();
        hash += EffectTime.GetHashCode();
        hash += EffectStrength.GetHashCode();
        return hash;
    }
}
