using MemoryPack;
using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Base;

/// <summary>
/// Represent an Abstract Core Item.
/// </summary>
[MemoryPackable(GenerateType.NoGenerate)]
public abstract partial class CoreItem : ICloneable, IEquatable<CoreItem>, IEqualityComparer<CoreItem>
{
    /// <summary>
    /// A Unique Id / Name for the Item
    /// </summary>
    public string Id { get; set; } = string.Empty;
    /// <summary>
    /// Type of the Item.
    /// <br>Declaring please use nameof(Class)</br>
    /// </summary>
    public string ItemType { get; set; } = string.Empty;
    /// <summary>
    /// Weight of the Item. How heavy is it.
    /// <br>Unit is KG [Kilogramm]</br>
    /// </summary>
    public decimal Weight { get; set; }
    /// <summary>
    /// Volume of the Item. How much space does it need.
    /// <br>Unit is L [Liter]</br>
    /// </summary>
    public decimal Volume { get; set; }
    /// <summary>
    /// Path to Instantiate the Item.
    /// </summary>
    public string AssetPath { get; set; } = string.Empty;
    /// <summary>
    /// Tags for the Item. 
    /// <br>Many Items check with Tags. You can use this system.</br>
    /// </summary>
    public List<string> Tags { get; set; } = [];

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"{Id} {ItemType} {Weight} {Volume} {AssetPath} Tags: {string.Join(", ", Tags)}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        return obj.GetHashCode() == this.GetHashCode();
    }

    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Id))
            hash += Id.GetHashCode();
        if (!string.IsNullOrEmpty(ItemType))
            hash += ItemType.GetHashCode();
        hash += Weight.GetHashCode();
        hash += Volume.GetHashCode();
        if (!string.IsNullOrEmpty(AssetPath))
            hash += AssetPath.GetHashCode();
        if (Tags.Count != 0)
            hash += (int)Tags.Select(x => x.GetHashCode()).Average();
        return hash;
    }

    public bool Equals(CoreItem? other)
    {
        if (other == null)
            return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    public bool Equals(CoreItem? x, CoreItem? y)
    {
        if (x == null && y == null)
            return true;
        if (x == null)
            return false;
        if (y == null)
            return false;
        return x.GetHashCode() == y.GetHashCode();
    }

    public int GetHashCode([DisallowNull] CoreItem obj)
    {
        if (obj == null)
            return 0;
        return obj.GetHashCode();
    }
}