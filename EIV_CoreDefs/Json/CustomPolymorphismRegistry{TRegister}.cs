/// <summary>
/// Represent a custom registry for json polymorphism.
/// </summary>
/// <typeparam name="TRegister">The type to register only.</typeparam>
public class CustomPolymorphismRegistry<TRegister> : PolymorphismRegistry<TRegister>
{
    /// <summary>
    /// Gets the dicriminator.
    /// </summary>
    public string Dicriminator { get; init; } = string.Empty;

    /// <inheritdoc/>
    protected override string DiscriminatorName => Dicriminator;
}
