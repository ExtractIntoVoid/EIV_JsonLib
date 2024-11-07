using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultBackpack : DefaultItem, IBackpack
{
    public decimal MaxItemWeight { get; set; }
    public decimal CurrentWeight { get; set; }
    public override string ItemType { get; set; } = nameof(IBackpack);
    public decimal MaxItemVolume { get; set; }
    public List<IItem> Items { get; set; } = [];

    public override string ToString()
    {
        return $"{base.ToString()} | {MaxItemWeight} {CurrentWeight} {MaxItemVolume}";
    }
}
