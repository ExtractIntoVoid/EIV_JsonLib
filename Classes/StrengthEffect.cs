using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Classes;

[MessagePackFormatter(typeof(StrengthEffectFormatter))]
public class StrengthEffect
{
    public int Min { get; set; }
    public int Max { get; set; }
    public List<string> ApplyTo { get; set; } = new();
}
