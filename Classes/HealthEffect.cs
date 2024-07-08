using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Classes;

[MessagePackFormatter(typeof(HealthEffectFormatter))]
public class HealthEffect : BaseNPEffect
{
    public string Cause { get; set; } = string.Empty;
}
