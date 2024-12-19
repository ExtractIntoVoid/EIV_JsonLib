using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Magazine : CoreItem
{
    /// <summary>
    /// List of <see cref="Ammo"/> inside of the <see cref="Magazine"/>
    /// </summary>
    [MemoryPackAllowSerialize]
    public List<Ammo> Ammunitions { get ; set ; } = [];

    /// <summary>
    /// Maximum capacity of the <see cref="Ammunitions"/>
    /// </summary>
    public uint MaxMagSize { get ; set ; }

    /// <summary>
    /// What <see cref="Ammo"/> Types/Tags does it support.
    /// </summary>
    public List<string> SupportedAmmos { get ; set ; } = [];

    public override string ToString()
    {
        return $"{base.ToString()} Ammos: ({string.Join(" ,", Ammunitions)}), MaxMagSize: {MaxMagSize}, SupportedAmmos: {string.Join(" ,", SupportedAmmos)}";
    }

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (Ammunitions.Count != 0)
            hash += (int)Ammunitions.Select(x => x.GetHashCode()).Average();
        hash += MaxMagSize.GetHashCode();
        if (SupportedAmmos.Count != 0)
            hash += (int)SupportedAmmos.Select(x => x.GetHashCode()).Average();
        return hash;
    }
}
