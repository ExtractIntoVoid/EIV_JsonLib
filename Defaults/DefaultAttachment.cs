using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultAttachment : DefaultItem, IAttachment
{
    public List<string> GunSupport { get; set; } = [];
    public List<string> RequiredGunTags { get; set; } = [];
    public override string ItemType { get; set; } = nameof(IAttachment);

    public override string ToString()
    {
        return $"{base.ToString()} | {GunSupport.Count} {RequiredGunTags.Count}";
    }
}
