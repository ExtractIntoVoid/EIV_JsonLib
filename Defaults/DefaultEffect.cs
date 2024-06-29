using EIV_JsonLib.Classes;
using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultEffect : IEffect
{
    public string EffectID { get; set; } = string.Empty;
    public EffectType EffectType { get; set; } = EffectType.Mixed;
    public HealthEffect Health { get; set; } = new();
    public BaseNPEffect Energy { get; set; } = new();
    public TimeEffect Time { get; set; } = new();
    public StrengthEffect Strength { get; set; } = new();
    public List<string> AppliedFrom { get; set; } = new();
    public List<string> AppliedTo { get; set; } = new();
    public string UseClass { get; set; } = string.Empty;
}
