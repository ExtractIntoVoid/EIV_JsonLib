using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class HealthEffect : BaseNPEffect
{
    public string Cause { get; set; } = string.Empty;
}
