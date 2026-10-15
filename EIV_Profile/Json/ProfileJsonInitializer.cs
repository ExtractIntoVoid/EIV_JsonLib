using EIV_Profile.ProfileModules;

namespace EIV_Profile.Json;

/// <summary>
/// Provides json polymorphism register.
/// </summary>
public static class ProfileJsonInitializer
{
    /// <summary>
    /// Gets the <see cref="IProfileModule"/> polymorphism registry.
    /// </summary>
    public static CustomPolymorphismRegistry<IProfileModule> IProfileModulePolymorphismRegistry { get; } = new() { Dicriminator = "Type" };

    /// <summary>
    /// Initialize core polymorphisms and resolvers.
    /// </summary>
    public static void Initialize()
    {
        JsonSerializerConvert.Resolvers.Add(ProfileSourceGenContext.Default);
        IProfileModulePolymorphismRegistry.Register<StatusEffectModule>(nameof(StatusEffectModule));

        IProfileModulePolymorphismRegistry.Register<MinMaxValueModule<int>>(JsonSerializerConvert.NameWithGenerics(typeof(MinMaxValueModule<int>)));
        IProfileModulePolymorphismRegistry.Register<MinMaxValueModule<float>>(JsonSerializerConvert.NameWithGenerics(typeof(MinMaxValueModule<float>)));
        IProfileModulePolymorphismRegistry.Register<MinMaxValueModule<double>>(JsonSerializerConvert.NameWithGenerics(typeof(MinMaxValueModule<double>)));
        IProfileModulePolymorphismRegistry.Register<MinMaxValueModule<bool>>(JsonSerializerConvert.NameWithGenerics(typeof(MinMaxValueModule<bool>)));

        IProfileModulePolymorphismRegistry.Register<ValueModule<int>>(JsonSerializerConvert.NameWithGenerics(typeof(ValueModule<int>)));
        IProfileModulePolymorphismRegistry.Register<ValueModule<float>>(JsonSerializerConvert.NameWithGenerics(typeof(ValueModule<float>)));
        IProfileModulePolymorphismRegistry.Register<ValueModule<double>>(JsonSerializerConvert.NameWithGenerics(typeof(ValueModule<double>)));
        IProfileModulePolymorphismRegistry.Register<ValueModule<bool>>(JsonSerializerConvert.NameWithGenerics(typeof(ValueModule<bool>)));

        IProfileModulePolymorphismRegistry.Register<ReadOnlyValueModule<int>>(JsonSerializerConvert.NameWithGenerics(typeof(ReadOnlyValueModule<int>)));
        IProfileModulePolymorphismRegistry.Register<ReadOnlyValueModule<float>>(JsonSerializerConvert.NameWithGenerics(typeof(ReadOnlyValueModule<float>)));
        IProfileModulePolymorphismRegistry.Register<ReadOnlyValueModule<double>>(JsonSerializerConvert.NameWithGenerics(typeof(ReadOnlyValueModule<double>)));
        IProfileModulePolymorphismRegistry.Register<ReadOnlyValueModule<bool>>(JsonSerializerConvert.NameWithGenerics(typeof(ReadOnlyValueModule<bool>)));

        JsonSerializerConvert.Polymorphisms.Add(IProfileModulePolymorphismRegistry);
    }
}
