using EIV_JsonLib.Formatters;
using MessagePack;
using Newtonsoft.Json;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(GunFormatter))]
public interface IGun : IItem
{
    //  IMagazine's BaseID
    public List<string> MagazineSupport { get; set; }
    public List<string> AmmoSupported { get; set; }

    [JsonIgnore]
    public IMagazine? Magazine { get; set; }
    // TODO This:
    // public List<IAttachment> Attachments { get; set; }
}
