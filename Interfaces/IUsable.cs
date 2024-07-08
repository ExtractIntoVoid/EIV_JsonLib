using Newtonsoft.Json;

namespace EIV_JsonLib.Interfaces;

public interface IUsable : IItem
{
    [JsonIgnore]
    bool CanUse { get; set; }
    public decimal UseTime { get; set; }
}
