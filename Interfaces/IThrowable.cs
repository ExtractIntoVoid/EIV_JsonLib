using EIV_JsonLib.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(ThrowableFormatter))]
public interface IThrowable : IUsable
{
    public decimal FuseTime { get; set; }
}
