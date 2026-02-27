using EIV_JsonLib.Base;
using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class GunMod : CoreItem
{
    public List<string> GunSupport { get; set; } = [];
    public List<string> RequiredGunTags { get; set; } = [];

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (GunSupport.Count != 0)
            hash += (int)GunSupport.Select(x => x.GetHashCode()).Average(); 
        if (RequiredGunTags.Count != 0)
            hash += (int)RequiredGunTags.Select(x => x.GetHashCode()).Average();
        return hash;
    }
}
