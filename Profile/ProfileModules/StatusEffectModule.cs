using MemoryPack;

namespace EIV_JsonLib.Profile.ProfileModules;

[MemoryPackable]
public partial class StatusEffectModule : IProfileModule
{
    public required string Name { get; init; }
    public List<SideEffect> Effects { get; set; } = [];

    public override string ToString()
    {
        return $"Name: {Name}, Effects: ({string.Join("| ",Effects)})";
    }
}
