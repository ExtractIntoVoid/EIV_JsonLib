using Newtonsoft.Json;

namespace EIV_JsonLib.Modding;

public interface IJsonLibConverter
{
    public List<JsonConverter> GetJsonConverters();

    public JsonConverter? GetJsonConverter(string ItemType);
}
