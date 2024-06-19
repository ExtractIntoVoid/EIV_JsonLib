using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(ThrowableFormatter))]
public interface IThrowable : IUsable
{
    public decimal FuseTime { get; set; }
}
