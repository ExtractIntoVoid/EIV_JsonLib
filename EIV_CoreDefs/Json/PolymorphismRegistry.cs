using System.Text.Json.Serialization.Metadata;

public abstract class PolymorphismRegistry
{
    public Dictionary<string, Type> Types { get; } = [];

    public abstract void AddPolymorphism(JsonTypeInfo typeInfo);
}
