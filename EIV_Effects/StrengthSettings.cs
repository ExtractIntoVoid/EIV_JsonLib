using EIV_Pack;
using System.Collections.ObjectModel;

namespace EIV_Effects;

/// <summary>
/// Represent a strength settings.
/// </summary>
[EIV_Packable]
public partial class StrengthSettings
{
    /// <summary>
    /// Gets the minimum strength allowed.
    /// </summary>
    public int Min { get; init; }

    /// <summary>
    /// Gets the maximum strength allowed.
    /// </summary>
    public int Max { get; init; }

    /// <summary>
    /// Gets what modules the strength applied to.
    /// </summary>
    public Collection<string> ApplyTo { get; init; } = [];
}
