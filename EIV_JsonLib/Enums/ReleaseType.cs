namespace EIV_JsonLib;

/// <summary>
/// Specifies the release stage of the application.
/// </summary>
public enum ReleaseType : byte
{
    /// <summary>
    /// Cannot be determined.
    /// </summary>
    None,
    /// <summary>
    /// Represents the production stage.
    /// </summary>
    Production,
    /// <summary>
    /// Represents the testing stage for validating code behavior and functionality.
    /// </summary>
    Testing,
    /// <summary>
    /// Represents the development phase where nothing is final and can be changed at any moment.
    /// </summary>
    Development
}