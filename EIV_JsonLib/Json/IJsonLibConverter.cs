#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json;
#endif

namespace EIV_JsonLib.Json;

public interface IJsonLibConverter
{

#if NET8_0_OR_GREATER
    public List<JsonConverter> GetJsonConverters();
#else
    public List<JsonConverter> GetJsonConverters();
#endif


    public Type? GetType(string ItemType);
}
