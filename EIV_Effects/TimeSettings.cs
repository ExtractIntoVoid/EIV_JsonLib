using EIV_Pack;

namespace EIV_Effects;

/// <summary>
/// Represent a time settings.
/// </summary>
[EIV_Packable]
public partial class TimeSettings
{
    /// <summary>
    /// Gets the time the effect last if no time set.
    /// </summary>
    public double Initial { get; init; }

    /// <summary>
    /// Gets the minimum time allowed.
    /// </summary>
    public double Min { get; init; }

    /// <summary>
    /// Gets the maximum time allowed.
    /// </summary>
    public double Max { get; init; }

    /// <summary>
    /// Gets the time to wait until effects applied.
    /// </summary>
    public double WaitUntilApply { get; init; }
}
