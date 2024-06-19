using EIV_JsonMP.Formatters;
using MessagePack;
using Newtonsoft.Json;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(BackpackFormatter))]
public interface IBackpack : IItem
{
    public decimal MaxItemWeight { get; set; }

    [JsonIgnore]
    public decimal CurrentWeight { get; set; }
}
