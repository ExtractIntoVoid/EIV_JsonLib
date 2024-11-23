using EIV_JsonLib.Base;
using EIV_JsonLib.Interface;
using MemoryPack;

namespace EIV_JsonLib;

[MemoryPackable]
public partial class ArmorPlate : ItemBase, IDurable
{
    public string Material { get; set; } = string.Empty;
    public uint Durability { get; set; }
}
