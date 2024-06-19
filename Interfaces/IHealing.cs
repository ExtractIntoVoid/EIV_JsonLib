using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(HealingFormatter))]
public interface IHealing : IUsable
{
    public decimal HealAmount { get; set; }

    // IEffect's BaseID I guess
    public List<string> SideEffect { get; set; }
}
