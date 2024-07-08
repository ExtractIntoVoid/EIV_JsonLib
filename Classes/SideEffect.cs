using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Classes;

[MessagePackFormatter(typeof(SideEffectFormatter))]
public class SideEffect
{
    public string EffectName { get; set; } = string.Empty;
    public int EffectTime { get; set; }
    public int EffectStrength { get; set; }
}
