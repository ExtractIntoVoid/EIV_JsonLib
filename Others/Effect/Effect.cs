﻿using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Effect
{
    public string EffectID { get; set; } = string.Empty;
    public EffectType EffectType { get; set; } = EffectType.Mixed;
    public HealthEffect Health { get; set; } = new();
    public BaseNPEffect Energy { get; set; } = new();
    public TimeEffect Time { get; set; } = new();
    public StrengthEffect Strength { get; set; } = new();
    public List<string> AppliedFrom { get; set; } = new();
    public string UseClass { get; set; } = string.Empty;

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
