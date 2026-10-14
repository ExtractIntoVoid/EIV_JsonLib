using EIV_Items.Core;
using System.Collections.ObjectModel;

namespace EIV_Items.Interfaces;

/// <summary>
/// Storage Interface, makes inventory slots available for this item.
/// </summary>
public partial interface IStorage
{
    /// <summary>
    /// Gets max size for the <see cref="Items"/>.
    /// </summary>
    public uint MaxSize { get; }

    /// <summary>
    /// Gets max weight (In KG) for the <see cref="Items"/>.
    /// </summary>
    public double MaxWeight { get; }

    /// <summary>
    /// Gets max volume (In L) for the <see cref="Items"/>.
    /// </summary>
    public double MaxVolume { get; }

    /// <summary>
    /// Gets the stored <see cref="Collection{T}"/> of <see cref="CoreItem"/>s.
    /// </summary>
    public Collection<CoreItem> Items { get; }
}
