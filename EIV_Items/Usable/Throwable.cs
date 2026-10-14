using EIV_Items.Core;
using EIV_Pack;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a throwable item.
/// </summary>
[EIV_Packable]
public partial class Throwable : CoreUsable
{
    /// <inheritdoc />
    public override string ItemType { get; init; } = nameof(Throwable);

    /// <summary>
    /// Gets the time when the fuze ends.
    /// </summary>
    public double FuseTime { get; init; }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash += FuseTime.GetHashCode();
        return hash;
    }
}
