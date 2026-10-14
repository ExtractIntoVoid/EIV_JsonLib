using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

public abstract class PolymorphismRegistry<TRegister> : PolymorphismRegistry
{
    protected abstract string DiscriminatorName { get; }

    public void Register<T>(string name)
           where T : TRegister
    {
        Types[name] = typeof(T);
    }

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
