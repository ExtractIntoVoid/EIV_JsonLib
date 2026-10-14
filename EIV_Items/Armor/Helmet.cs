using EIV_Items.Core;
using EIV_Pack;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a helmet armor.
/// </summary>
[EIV_Packable]
public partial class Helmet : CoreArmor
{
    /// <inheritdoc />
    public override string ItemType { get; init; } = nameof(Helmet);

    /// <summary>
    /// Gets a value indicating whether the helmet has full head protection.
    /// </summary>
    public bool IsFullProtection { get; init; }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return base.GetHashCode() + IsFullProtection.GetHashCode();
    }
}
