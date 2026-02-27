using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class TimeEffect
{
    public double Initial { get; set; }
    public double Min { get; set; }
    public double Max { get; set; }
    public double WaitUntilApply { get; set; }
}
