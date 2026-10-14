using EIV_Items.Core;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Collections.ObjectModel;

namespace EIV_Items;

/// <summary>
/// Represent a storage stash.
/// </summary>
[EIV_Packable]
public partial class Stash : IStorage
{
    /// <inheritdoc/>
    public uint MaxSize { get; init; }

    /// <inheritdoc/>
    public double MaxWeight { get; init; }

    /// <inheritdoc/>
    public double MaxVolume { get; init; }

    /// <inheritdoc/>
    public Collection<CoreItem> Items { get; init; } = [];
}
