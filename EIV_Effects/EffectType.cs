namespace EIV_Effects;

/// <summary>
/// Defines identifiers for effect type.
/// </summary>
#pragma warning disable CA1028 // Enum Storage should be Int32
public enum EffectType : byte
#pragma warning restore CA1028 // Enum Storage should be Int32
{
    /// <summary>
    /// Represent an unknown type.
    /// </summary>
    Unknown,

    /// <summary>
    /// Represent an effect being technical.
    /// </summary>
    Technical,

    /// <summary>
    /// Represent an effect being mixed for entity.
    /// </summary>
    Mixed,

    /// <summary>
    /// Represent an effect being negative for entity.
    /// </summary>
    Negative,

    /// <summary>
    /// Represent an effect being positive for entity.
    /// </summary>
    Positive,
}
