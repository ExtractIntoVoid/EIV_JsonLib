using EIV_JsonLib.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(AttachmentFormatter))]
public interface IAttachment : IItem
{
    public List<string> GunSupport { get; set; }
    public List<string> RequiredGunTags { get; set; }
}
