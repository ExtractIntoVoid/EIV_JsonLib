using EIV_Items.Core;
using EIV_Pack;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a vest armor.
/// </summary>
[EIV_Packable]
public partial class Vest : CoreArmor
{
    /// <inheritdoc />
    public override string ItemType { get; init; } = nameof(Vest);
}
