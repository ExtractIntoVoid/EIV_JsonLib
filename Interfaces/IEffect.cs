using EIV_JsonLib.Classes;
using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(EffectFormatter))]
public interface IEffect : ICloneable
{
    public string EffectID { get; set; }
    public EffectType EffectType { get; set; }
    public HealthEffect Health { get; set; }
    public BaseNPEffect Energy { get; set; }
    public TimeEffect Time { get; set; }
    public StrengthEffect Strength { get; set; }
    public List<string> AppliedFrom { get; set; }
    public string UseClass { get; set; }
}
