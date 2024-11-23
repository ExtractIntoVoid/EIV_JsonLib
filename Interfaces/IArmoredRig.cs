using EIV_JsonLib.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(ArmoredRigFormatter))]
public interface IArmoredRig : IRig, IArmor
{
}
