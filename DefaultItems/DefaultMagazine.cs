﻿using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.DefaultItems;

public class DefaultMagazine : IMagazine
{
    public List<string> Ammunition { get; set; } = [];
    public uint MagSize { get; set; }
    public List<string> SupportedAmmo { get; set; } = [];
    public string BaseID { get; set; } = string.Empty;
    public string ItemType { get; set; } = nameof(IMagazine);
    public decimal Weight { get; set; }
    public string AssetPath { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = [];
    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"{BaseID} {ItemType} {Weight} {AssetPath}";
    }
}
