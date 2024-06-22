using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultArmor : DefaultItem, IArmor
{
    public decimal BlockEfficacy { get; set; }
    public decimal ArmorWeight { get; set; }
    public override string ItemType { get; set; } = nameof(IArmor);

    public override string ToString()
    {
        return $"{base.ToString()} | {BlockEfficacy} {ArmorWeight}";
    }
}
