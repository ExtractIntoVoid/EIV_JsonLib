using MemoryPack;

namespace EIV_JsonLib.Profile.ProfileModules;

[MemoryPackable]
public partial class ValueModule<T> : IProfileModule
{
    public required string Name { get; init; }
    public required T Value { get; set; }
    public override string ToString()
    {
        return $"Name: {Name}, T: {typeof(T).Name}, Val: {Value}";
    }
}
