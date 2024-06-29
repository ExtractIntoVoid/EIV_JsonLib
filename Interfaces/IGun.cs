using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(GunFormatter))]
public interface IGun : IItem
{
    //  IMagazine's BaseID
    public List<string> MagazineSupport { get; set; }
    public List<string> AmmoSupported { get; set; }
    public List<string> Attachments { get; set; }
    public IMagazine? Magazine { get; set; }
}
