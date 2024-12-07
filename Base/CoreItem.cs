using MemoryPack;

namespace EIV_JsonLib.Base;

/// <summary>
/// Represent an Abstract Core Item.
/// </summary>
[MemoryPackable(GenerateType.NoGenerate)]
public abstract partial class CoreItem : ICloneable
{
    /// <summary>
    /// A Unique Id/Name for the Item
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
    /// Path to Instantiate the Item in Godot
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
        return Id.GetHashCode() ^ ItemType.GetHashCode() ^ Weight.GetHashCode() + Volume.GetHashCode() - AssetPath.GetHashCode();
    }
}