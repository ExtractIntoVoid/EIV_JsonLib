using MemoryPack;

namespace EIV_JsonLib.Profile.ProfileModules;

[MemoryPackable]
public partial class MinMaxValueModule<T> : ValueModule<T>, IProfileModule
{
    public required T MinValue { get; init; }
    public required T MaxValue { get; init; }

    public override string ToString()
    {
        return $"Name: {Name}, T: {typeof(T).Name}, Min: {MinValue}, Max: {MaxValue}, Val: {Value}";
    }
}
