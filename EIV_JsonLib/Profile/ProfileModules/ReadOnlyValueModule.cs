using EIV_Pack;

namespace EIV_JsonLib.Profile.ProfileModules;

[EIV_Packable]
public partial class ReadOnlyValueModule<T> : IProfileModule
{
    public required string Name { get; init; }
    public required string ModuleType { get; set; }
    public required T Value { get; init; }
    public override string ToString()
    {
        return $"Name: {Name}, T: {typeof(T).Name}, Val: {Value}";
    }
    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Name))
            hash += Name.GetHashCode();
        if (Value != null)
            hash += Value.GetHashCode();
        return hash;
    }
}
