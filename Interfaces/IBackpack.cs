using EIV_JsonLib.Formatters;
using MessagePack;
using Newtonsoft.Json;

namespace EIV_JsonLib.Interfaces;

[MessagePackFormatter(typeof(BackpackFormatter))]
public interface IBackpack : IItem
{
    public decimal MaxItemWeight { get; set; }
    public decimal MaxItemVolume { get; set; }

    [JsonIgnore]
    public decimal CurrentWeight { get; set; }
    public List<IItem> Items { get; set; }
}
