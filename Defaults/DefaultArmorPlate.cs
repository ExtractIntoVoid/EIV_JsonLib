using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultArmorPlate : DefaultItem, IArmorPlate
{
    public override string ItemType { get; set; } = nameof(IArmorPlate);
    public string Material { get; set; } = string.Empty;
    public uint Durability { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()} | {Material} {Durability}";
    }
}
