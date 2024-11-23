using MemoryPack;

namespace EIV_JsonLib.Base;

[MemoryPackable(GenerateType.NoGenerate)]
public abstract partial class ItemBase : ICloneable
{
    public string BaseID { get; set; } = string.Empty;
    public string ItemType { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Volume { get; set; }
    public string AssetPath { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = [];

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"{BaseID} {ItemType} {Weight} {Volume} {AssetPath} Tags: {string.Join(", ", Tags)}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        return obj.GetHashCode() == this.GetHashCode();
    }

    public override int GetHashCode()
    {
        return BaseID.GetHashCode() ^ ItemType.GetHashCode() ^ Weight.GetHashCode() + Volume.GetHashCode() - AssetPath.GetHashCode();
    }
}