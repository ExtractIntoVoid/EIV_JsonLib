﻿using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.DefaultItems;

public class DefaultArmoredRig : IArmoredRig
{
    public decimal BlockEfficacy { get; set; }
    public decimal ArmorWeight { get; set; }
    public string BaseID { get; set; } = string.Empty;
    public string ItemType { get; set; } = nameof(IArmoredRig);
    public decimal Weight { get; set; }
    public string AssetPath { get; set; } = string.Empty;
    public uint MaxItem { get; set; }
    public List<string> ItemTypesAccepted { get; set; } = [];
    public List<string> SpecificItemsAccepted { get; set; } = [];
    public List<string> ArmorPlateAccepted { get; set; } = [];
    public List<string> ItemIds { get; set; } = [];
    public string? PlateSlotId { get; set; }
    public List<string> Tags { get; set; } = [];

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"{BaseID} {ItemType} {Weight} {AssetPath} | {BlockEfficacy} {ArmorWeight}";
    }
}
