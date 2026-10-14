public class CustomPolymorphismRegistry<TRegister> : PolymorphismRegistry<TRegister>
{
    public string Dicriminator { get; init; }

    protected override string DiscriminatorName => Dicriminator;
}
