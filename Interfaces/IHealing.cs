using EIV_JsonLib.Classes;
using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(HealingFormatter))]
public interface IHealing : IUsable
{
    public int HealAmount { get; set; }
    public List<SideEffect> SideEffects { get; set; }
}
