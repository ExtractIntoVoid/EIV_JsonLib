using EIV_JsonLib.Interfaces;

namespace EIV_JsonLib.Defaults;

public class DefaultStash : IStash
{
    public uint MaxSize { get; set; }
    public uint MaxWeight { get; set; }
    public List<string> Items { get; set; } = [];
    public decimal MaxVolume { get; set; }

    public override string ToString()
    {
        return $"{MaxSize} {MaxWeight} {Items.Count} {MaxVolume}";
    }
}
