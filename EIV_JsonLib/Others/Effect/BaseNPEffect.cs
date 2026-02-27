using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class BaseNPEffect
{
    public int Negative { get; set; }
    public int Positive { get; set; }
}
