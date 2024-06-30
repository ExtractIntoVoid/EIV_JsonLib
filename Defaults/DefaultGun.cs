using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultGun : DefaultItem, IGun
{
    public List<string> MagazineSupport { get; set; } = [];
    public List<string> AmmoSupported { get; set; } = [];
    public override string ItemType { get; set; } = nameof(IGun);
    public IMagazine? Magazine { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()} | {string.Join(", ", MagazineSupport)} {AmmoSupported.Count} {Magazine == null}";
    }
}
