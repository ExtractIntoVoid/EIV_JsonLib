using EIV_Items.Profile.ProfileModules;

#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json;
#endif

namespace EIV_Items.Json;

internal class Internal_ProfileModuleConverter : IJsonLibConverter
{
    public Type? GetType(string ItemType)
    {
        return ItemType switch
        {
            "StatusEffectModule" => typeof(StatusEffectModule),
            "MinMaxValueModule|Int32" => typeof(MinMaxValueModule<int>),
            "MinMaxValueModule|Single" => typeof(MinMaxValueModule<float>),
            "MinMaxValueModule|Double" => typeof(MinMaxValueModule<double>),
            "MinMaxValueModule|Boolean" => typeof(MinMaxValueModule<bool>),
            "ValueModule|Int32" => typeof(ValueModule<int>),
            "ValueModule|Single" => typeof(ValueModule<float>),
            "ValueModule|Double" => typeof(ValueModule<double>),
            "ValueModule|Boolean" => typeof(ValueModule<bool>),
            "ReadOnlyValueModule|Int32" => typeof(ReadOnlyValueModule<int>),
            "ReadOnlyValueModule|Single" => typeof(ReadOnlyValueModule<float>),
            "ReadOnlyValueModule|Double" => typeof(ReadOnlyValueModule<double>),
            "ReadOnlyValueModule|Boolean" => typeof(ReadOnlyValueModule<bool>),
            _ => null,
        };
    }

    public List<JsonConverter> GetJsonConverters()
    {
        return
        [
            new ProfileModuleConverter()
        ];
    }
}