using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Gun : CoreUsable
{
    public List<string> MagazineSupport { get ; set ; } = [];
    public List<string> AmmoSupported { get ; set ; } = [];

    [MemoryPackAllowSerialize]
    public Magazine? Magazine { get ; set ; }
    public List<GunMod> GunMods { get; set; } = [];
}
