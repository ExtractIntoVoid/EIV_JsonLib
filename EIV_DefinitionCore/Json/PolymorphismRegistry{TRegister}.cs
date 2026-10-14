using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

/// <summary>
/// Represent a registry for json polymorphism.
/// </summary>
/// <typeparam name="TRegister">The type to register only.</typeparam>
public abstract class PolymorphismRegistry<TRegister> : PolymorphismRegistry
{
    /// <summary>
    /// Gets the discriminator name.
    /// </summary>
    protected abstract string DiscriminatorName { get; }

    /// <summary>
    /// Register <typeparamref name="T"/> via name as <paramref name="name"/>.
    /// </summary>
    /// <typeparam name="T">Any <typeparamref name="TRegister"/> type.</typeparam>
    /// <param name="name">The name.</param>
    public void Register<T>(string name)
           where T : TRegister
    {
        Types[name] = typeof(T);
    }

    /// <inheritdoc/>
    public override void AddPolymorphism(JsonTypeInfo typeInfo)
    {
        if (typeInfo == null || typeInfo.Type != typeof(TRegister))
        {
            return;
        }

        typeInfo.PolymorphismOptions ??= new JsonPolymorphismOptions
        {
            TypeDiscriminatorPropertyName = DiscriminatorName,
            UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
        };

        foreach (var kvp in Types)
        {
            typeInfo.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(kvp.Value, kvp.Key));
        }
    }
}
