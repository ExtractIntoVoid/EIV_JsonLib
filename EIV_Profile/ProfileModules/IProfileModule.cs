using System.Text.Json.Serialization;

namespace EIV_Profile.ProfileModules;

/// <summary>
/// An interface for declaring a module for player profile.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
public interface IProfileModule
{
    /// <summary>
    /// Gets the profile name.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Gets the module type.
    /// </summary>
    public string ModuleType { get; init; }
}
