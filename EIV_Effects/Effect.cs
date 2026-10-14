using EIV_Pack;

namespace EIV_Effects;

/// <summary>
/// Represent an effect.
/// </summary>
[EIV_Packable]
public partial class Effect : ICloneable
{
    /// <summary>
    /// Gets the unique id / name for the effect.
    /// </summary>
    public string Id { get; init; } = string.Empty;

    /// <summary>
    /// Gets the effects type.
    /// </summary>
    public EffectType Type { get; init; }

    /// <summary>
    /// Gets the modules math settings.
    /// </summary>
    public Dictionary<string, MathValueInt> ModulesMath { get; init; } = [];

    /// <summary>
    /// Gets the time settings.
    /// </summary>
    public TimeSettings Time { get; init; } = new();

    /// <summary>
    /// Gets the strength settings.
    /// </summary>
    public StrengthSettings Strength { get; init; } = new();

    /// <inheritdoc/>
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}