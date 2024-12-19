using MemoryPack;

namespace EIV_JsonLib.Interfaces;

[MemoryPackable(GenerateType.NoGenerate)]
public partial interface IDurable
{
    /// <summary>
    /// How long the item "live" until wown off.
    /// </summary>
    public uint Durability { get; set; }
}
