using MemoryPack;
using System.Reflection;

namespace EIV_JsonLib.Profile.ProfileModules;

[MemoryPackable]
public partial class StatusEffectModule : IProfileModule
{
    public required string Name { get; init; }
    public string ModuleType { get; set; } = nameof(StatusEffectModule);
    public List<SideEffect> Effects { get; set; } = [];

    public override string ToString()
    {
        return $"Name: {Name}, Effects: ({string.Join("| ",Effects)})";
    }

    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Name))
            hash += Name.GetHashCode();
        if (Effects.Count != 0)
            hash += (int)Effects.Select(x => x.GetHashCode()).Average();
        return hash;
    }
}
