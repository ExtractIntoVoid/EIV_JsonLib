﻿using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(ItemFormatter))]
public interface IItem : ICloneable
{
    public string BaseID { get; set; }
    public string ItemType { get; set; }
    public decimal Weight { get; set; }
    public decimal Volume { get; set; }
    public string AssetPath { get; set; }
    public List<string> Tags { get; set; }
}
