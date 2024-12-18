using MemoryPack;

namespace EIV_JsonLib.Interfaces;

/// <summary>
/// Wearable interface, let the player Wear this item.
/// </summary>
[MemoryPackable(GenerateType.NoGenerate)]
public partial interface IWearable
{
    /// <summary>
    /// Slot where is the Item can be put.
    /// </summary>
    public string Slot { get; set; }
}
