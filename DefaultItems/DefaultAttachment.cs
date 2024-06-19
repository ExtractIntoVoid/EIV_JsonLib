using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.DefaultItems;

public class DefaultAttachment : IAttachment
{
    public List<string> GunSupport { get; set; } = [];
    public List<string> RequiredGunTags { get; set; } = [];
    public string BaseID { get; set; } = string.Empty;
    public string ItemType { get; set; } = nameof(IAttachment);
    public decimal Weight { get; set; }
    public string AssetPath { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = [];

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"{BaseID} {ItemType} {Weight} {AssetPath} | {GunSupport.Count} {RequiredGunTags.Count}";
    }
}
