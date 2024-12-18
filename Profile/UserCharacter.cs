using EIV_JsonLib.Profile.ProfileModules;
using MemoryPack;

namespace EIV_JsonLib.Profile;

[MemoryPackable]
public partial class UserCharacter
{
    public string Name { get; set; } = string.Empty;
    public string Origin { get; set; } = string.Empty;
    public DateTimeOffset CreationDate { get; set; }

    [MemoryPackAllowSerialize]
    public Inventory Inventory { get; set; } = new();

    [MemoryPackAllowSerialize]
    public List<IProfileModule> Modules { get; set; } = [];

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
}