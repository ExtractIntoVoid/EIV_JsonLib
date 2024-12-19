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

    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Name))
            hash += Name.GetHashCode();
        if (Value != null)
            hash += Value.GetHashCode();
        if (MinValue != null)
            hash += MinValue.GetHashCode();
        if (MaxValue != null)
            hash += MaxValue.GetHashCode();
        return hash;
    }
}
