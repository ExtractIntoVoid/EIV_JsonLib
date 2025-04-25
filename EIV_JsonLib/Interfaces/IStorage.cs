using EIV_JsonLib.Base;
using MemoryPack;

namespace EIV_JsonLib.Interfaces;

/// <summary>
/// Storage Interface, makes inventory slots available for this item.
/// </summary>
[MemoryPackable(GenerateType.NoGenerate)]
public partial interface IStorage
{
    /// <summary>
    /// Max Size for the <see cref="Items"/>
    /// </summary>
    public uint MaxSize { get; set; }
    /// <summary>
    /// Max Weight (In KG) for the <see cref="Items"/>
    /// </summary>
    public decimal MaxWeight { get; set; }
    /// <summary>
    /// Max Volume (In L) for the <see cref="Items"/>
    /// </summary>
    public decimal MaxVolume { get; set; }
    /// <summary>
    /// Stores a <see cref="List{}"/> of <see cref="CoreItem"/>s.
    /// </summary>
    [MemoryPackAllowSerialize]
    public List<CoreItem> Items { get; set; }
}
