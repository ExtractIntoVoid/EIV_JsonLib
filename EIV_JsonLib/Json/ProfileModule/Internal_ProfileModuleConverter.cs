using EIV_JsonLib.Profile.ProfileModules;
using System.Text.Json.Serialization;

namespace EIV_JsonLib.Json;

internal class Internal_ProfileModuleConverter : IJsonLibConverter
{
    public Type? GetType(string ItemType)
    {
        return ItemType switch
        {
            "StatusEffectModule" => typeof(StatusEffectModule),
            "MinMaxValueModule|Int32" => typeof(MinMaxValueModule<int>),
            "MinMaxValueModule|Single" => typeof(MinMaxValueModule<float>),
            "MinMaxValueModule|Decimal" => typeof(MinMaxValueModule<decimal>),
            "MinMaxValueModule|Boolean" => typeof(MinMaxValueModule<bool>),
            "ValueModule|Int32" => typeof(ValueModule<int>),
            "ValueModule|Single" => typeof(ValueModule<float>),
            "ValueModule|Decimal" => typeof(ValueModule<decimal>),
            "ValueModule|Boolean" => typeof(ValueModule<bool>),
            "ReadOnlyValueModule|Int32" => typeof(ReadOnlyValueModule<int>),
            "ReadOnlyValueModule|Single" => typeof(ReadOnlyValueModule<float>),
            "ReadOnlyValueModule|Decimal" => typeof(ReadOnlyValueModule<decimal>),
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