using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Profile.ProfileModules;

public static partial class ProfileModuleHelper
{
    public static T? GetProfileModule<T>(this UserCharacter character, [NotNull] string name) where T : IProfileModule
    {
        return (T?)character.Modules.FirstOrDefault(x => x is T && x.Name == name);
    }

    public static bool TryGetProfileModule<T>(this UserCharacter character, [NotNull] string name, out T? out_t) where T : IProfileModule
    {
        out_t = default;
        out_t = (T?)character.Modules.FirstOrDefault(x => x is T && x.Name == name);
        return out_t != null;
    }

    public static IProfileModule? GetProfileModuleByName(this UserCharacter character, [NotNull] string name)
    {
        return character.Modules.FirstOrDefault(x => x.Name == name);
    }

    public static bool GetProfileModuleNameExist(this UserCharacter character, [NotNull] string name)
    {
        return character.Modules.Exists(x => x.Name == name);
    }
}
