using MemoryPack;

namespace EIV_JsonLib.Profile.ProfileModules;

[MemoryPackable(GenerateType.NoGenerate)]
public partial interface IProfileModule
{
    public string Name { get; init; }
    public string ModuleType { get; set; }
}
