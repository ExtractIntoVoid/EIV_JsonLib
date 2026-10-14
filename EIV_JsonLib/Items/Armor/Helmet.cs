using EIV_Items.Base;
using EIV_Pack;

namespace EIV_Items;

[EIV_Packable]
public partial class Helmet : CoreArmor
{
    public bool IsFullProtection { get; set; }

    public override int GetHashCode()
    {
        return base.GetHashCode() + IsFullProtection.GetHashCode();
    }
}
