using EIV_JsonLib.Base;
using EIV_JsonLib.Interfaces;
using MemoryPack;
using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class Stash : IEquatable<Stash>, IEqualityComparer<Stash>, IStorage
{
    public uint MaxSize { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal MaxVolume { get; set; }
    [MemoryPackAllowSerialize]
    public List<CoreItem> Items { get; set; } = [];

    public bool Equals(Stash? other)
    {
        if (other == null)
            return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    public bool Equals(Stash? x, Stash? y)
    {
        if (x == null && y == null)
            return true;
        if (x == null)
            return false;
        if (y == null)
            return false;
        return x.GetHashCode() == y.GetHashCode();
    }

    public override int GetHashCode()
    {
        int hash = MaxSize.GetHashCode() + MaxWeight.GetHashCode() ^ MaxVolume.GetHashCode();
        if (Items.Count != 0)
            hash += (int)Items.Select(x => x.GetHashCode()).Average();
        return hash;
    }

    public int GetHashCode([DisallowNull] Stash obj)
    {
        return obj.GetHashCode();
    }

    public override string ToString()
    {
        return $"MaxSize: {MaxSize}, MaxWeight: {MaxWeight}, MaxVolume: {MaxVolume}, Items: ({string.Join(" | ", Items)})";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Stash);
    }
}
