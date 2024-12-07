using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Magazine : CoreItem
{
    public List<string> Ammunitions { get ; set ; } = [];
    public uint MaxMagSize { get ; set ; }
    public List<string> SupportedAmmos { get ; set ; } = [];

    public override string ToString()
    {
        return $"{base.ToString()} Ammos: {string.Join(" ,", Ammunitions)}, MaxMagSize: {MaxMagSize}, SupportedAmmos: {string.Join(" ,", SupportedAmmos)}";
    }

    public override int GetHashCode()
    {
        return base.GetHashCode() + MaxMagSize.GetHashCode();
    }
}
