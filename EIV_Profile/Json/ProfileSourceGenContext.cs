using EIV_Profile.ProfileModules;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace EIV_Profile.Json
{
    /// <summary>
    /// Repressent an item source generated context.
    /// </summary>
    [JsonSourceGenerationOptions]

    [JsonSerializable(typeof(IProfileModule))]

    [JsonSerializable(typeof(StatusEffectModule))]

    [JsonSerializable(typeof(MinMaxValueModule<int>))]
    [JsonSerializable(typeof(MinMaxValueModule<float>))]
    [JsonSerializable(typeof(MinMaxValueModule<double>))]
    [JsonSerializable(typeof(MinMaxValueModule<bool>))]

    [JsonSerializable(typeof(ValueModule<int>))]
    [JsonSerializable(typeof(ValueModule<float>))]
    [JsonSerializable(typeof(ValueModule<double>))]
    [JsonSerializable(typeof(ValueModule<bool>))]

    [JsonSerializable(typeof(ReadOnlyValueModule<int>))]
    [JsonSerializable(typeof(ReadOnlyValueModule<float>))]
    [JsonSerializable(typeof(ReadOnlyValueModule<double>))]
    [JsonSerializable(typeof(ReadOnlyValueModule<bool>))]

    [JsonSerializable(typeof(UserCharacter))]
    public partial class ProfileSourceGenContext : JsonSerializerContext
    {
    }
}
