using EIV_JsonLib.Classes;
using EIV_JsonLib.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(ConsumableFormatter))]
public interface IConsumable : IUsable
{
    public uint MaxUses { get; set; }
    public int EnergyRestore { get; set; }
    public int HydrationRestore { get; set; }
    public List<SideEffect> SideEffects { get; set; }
}
