using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Classes;

[MessagePackFormatter(typeof(BaseNPEffectFormatter))]
public class BaseNPEffect
{
    public int Negative { get; set; }
    public int Positive { get; set; }
}
