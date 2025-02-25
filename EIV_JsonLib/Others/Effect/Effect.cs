using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Effect
{
    public string EffectName { get; set; } = string.Empty;
    public EffectType EffectType { get; set; } = EffectType.Mixed;

    [MemoryPackAllowSerialize]
    public HealthEffect Health { get; set; } = new();

    [MemoryPackAllowSerialize]
    public BaseNPEffect Energy { get; set; } = new();

    [MemoryPackAllowSerialize]
    public TimeEffect Time { get; set; } = new();

    [MemoryPackAllowSerialize]
    public StrengthEffect Strength { get; set; } = new();

    public List<string> AppliedFrom { get; set; } = [];

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
