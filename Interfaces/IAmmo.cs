using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(AmmoFormatter))]
public interface IAmmo : IDamageDealer
{
    public decimal Speed { get; set; }
}
