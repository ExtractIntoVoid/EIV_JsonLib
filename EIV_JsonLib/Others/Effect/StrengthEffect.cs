using EIV_Pack;

namespace EIV_JsonLib;

[EIV_Packable]
public partial class StrengthEffect
{
    public int Min { get; set; }
    public int Max { get; set; }
    public List<string> ApplyTo { get; set; } = [];
}
