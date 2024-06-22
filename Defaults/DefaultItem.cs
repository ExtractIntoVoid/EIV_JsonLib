using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultItem : IItem
{
    public virtual string BaseID { get; set; } = string.Empty;
    public virtual string ItemType { get; set; } = nameof(IItem);
    public virtual decimal Weight { get; set; }
    public virtual decimal Volume { get; set; }
    public virtual string AssetPath { get; set; } = string.Empty;
    public virtual List<string> Tags { get; set; } = [];
    public virtual object Clone()
    {
        return MemberwiseClone();
    }

    public override string ToString()
    {
        return $"{BaseID} {ItemType} {Weight} {Volume} {AssetPath} Tags: {string.Join(", ", Tags)}";
    }
}
