using System.Text.Json.Serialization.Metadata;

/// <summary>
/// Represent a registry for json polymorphism.
/// </summary>
public abstract class PolymorphismRegistry
{
    /// <summary>
    /// Gets the registered types.
    /// </summary>
    public Dictionary<string, Type> Types { get; } = [];

    /// <summary>
    /// Add polymorphism to <paramref name="typeInfo"/>.
    /// </summary>
    /// <param name="typeInfo">The json type.</param>
    public abstract void AddPolymorphism(JsonTypeInfo typeInfo);
}
