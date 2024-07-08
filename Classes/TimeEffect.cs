using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Classes;

[MessagePackFormatter(typeof(TimeEffectFormatter))]
public class TimeEffect
{
    public double Initial { get; set; }
    public double Min { get; set; }
    public double Max { get; set; }
    public double WaitUntilApply { get; set; }
}
