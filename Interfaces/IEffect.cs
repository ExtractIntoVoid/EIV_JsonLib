using EIV_JsonLib.Classes;

namespace EIV_JsonLib.Interfaces;

public interface IEffect
{
    public string EffectID { get; set; }
    public EffectType EffectType { get; set; }
    public HealthEffect Health { get; set; }
    public BaseNPEffect Energy { get; set; }
    public TimeEffect Time { get; set; }
    public StrengthEffect Strength { get; set; }
    public List<string> AppliedFrom { get; set; }
    public List<string> AppliedTo { get; set; }
}
