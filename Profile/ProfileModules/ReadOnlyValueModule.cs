using MemoryPack;

namespace EIV_JsonLib.Profile.ProfileModules;

[MemoryPackable]
public partial class ReadOnlyValueModule<T> : IProfileModule
{
    public required string Name { get; init; }
    public required T Value { get; init; }
    public override string ToString()
    {
        return $"Name: {Name}, T: {typeof(T).Name}, Val: {Value}";
    }
}
