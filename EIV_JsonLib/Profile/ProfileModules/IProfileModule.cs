using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Profile.ProfileModules;

public interface IProfileModule
{
    public string Name { get; init; }
    public string ModuleType { get; set; }
}
