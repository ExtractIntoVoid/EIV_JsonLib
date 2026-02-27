using EIV_JsonLib.Profile.ProfileModules;
using EIV_Pack;
using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Profile;

[EIV_Packable]
public partial class UserCharacter : IEquatable<UserCharacter>, IEqualityComparer<UserCharacter>
{
    public string Name { get; set; } = string.Empty;
    public string Origin { get; set; } = string.Empty;
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.MinValue;
    public Inventory Inventory { get; set; } = new();
    public List<IProfileModule> Modules { get; set; } = [];

    public bool Equals(UserCharacter? other)
    {
        if (other == null)
            return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    public bool Equals(UserCharacter? x, UserCharacter? y)
    {
        if (x == null && y == null)
            return true;
        if (x == null)
            return false;
        if (y == null)
            return false;
        return x.GetHashCode() == y.GetHashCode();
    }

    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Name))
            hash += Name.GetHashCode();
        if (!string.IsNullOrEmpty(Origin))
            hash += Origin.GetHashCode();
        hash += CreationDate.GetHashCode();
        if (Inventory != null)
            hash += Inventory.GetHashCode();
        if (Modules.Count != 0)
            hash += (int)Modules.Select(x => x.GetHashCode()).Average();
        return hash;
    }

    public int GetHashCode(
#if NET8_0_OR_GREATER
        [DisallowNull]
#endif
        UserCharacter obj)
    {
        return obj.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as UserCharacter);
    }
}