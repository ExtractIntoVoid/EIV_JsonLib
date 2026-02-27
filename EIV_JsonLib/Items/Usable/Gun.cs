using EIV_JsonLib.Base;
using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class Gun : CoreUsable
{
    public List<string> MagazineSupport { get ; set ; } = [];
    public List<string> AmmoSupported { get ; set ; } = [];
    public Magazine? Magazine { get ; set ; }
    public List<GunMod> GunMods { get; set; } = [];

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (MagazineSupport.Count != 0)
            hash += (int)MagazineSupport.Select(x => x.GetHashCode()).Average();
        if (AmmoSupported.Count != 0)
            hash += (int)AmmoSupported.Select(x => x.GetHashCode()).Average();
        if (Magazine != null)
            hash += Magazine.GetHashCode();
        if (GunMods.Count != 0)
            hash += (int)GunMods.Select(x => x.GetHashCode()).Average();
        return hash;
    }
}
