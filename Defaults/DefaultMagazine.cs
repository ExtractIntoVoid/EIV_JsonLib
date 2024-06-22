using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultMagazine : DefaultItem, IMagazine
{
    public List<string> Ammunition { get; set; } = [];
    public uint MaxMagSize { get; set; }
    public List<string> SupportedAmmo { get; set; } = [];
    public override string ItemType { get; set; } = nameof(IMagazine);

    public override string ToString()
    {
        return $"{base.ToString()} | {Ammunition.Count} {MaxMagSize} {SupportedAmmo.Count}";
    }
}
