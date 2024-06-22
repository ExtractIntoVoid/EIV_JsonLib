using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultThrowable : DefaultItem, IThrowable
{
    public decimal FuseTime { get; set; }
    public bool CanUse { get; set; }
    public decimal UseTime { get; set; }
    public override string ItemType { get; set; } = nameof(IThrowable);

    public override string ToString()
    {
        return $"{base.ToString()} | {FuseTime} {CanUse} {UseTime}";
    }
}
