using System.Text.Json.Serialization;

namespace EIV_JsonLib.Json;

public interface IJsonLibConverter
{
    public List<JsonConverter> GetJsonConverters();

    public Type? GetType(string ItemType);
}
