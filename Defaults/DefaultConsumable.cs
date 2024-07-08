using EIV_JsonLib.Classes;
using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults
{
    public class DefaultConsumable : DefaultItem, IConsumable
    {
        public override string ItemType { get; set; } = nameof(IConsumable);
        public uint MaxUses { get; set; }
        public int EnergyRestore { get; set; }
        public int HydrationRestore { get; set; }
        public List<SideEffect> SideEffects { get; set; } = [];
        public bool CanUse { get; set; } = true;
        public decimal UseTime { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} | {MaxUses} {EnergyRestore} {HydrationRestore} {SideEffects.Count} {CanUse} {UseTime}";
        }

    }
}
