using System.Diagnostics.CodeAnalysis;

namespace EIV_Items.Profile.ProfileModules;

public interface IProfileModule
{
    public string Name { get; init; }
    public string ModuleType { get; set; }
}
