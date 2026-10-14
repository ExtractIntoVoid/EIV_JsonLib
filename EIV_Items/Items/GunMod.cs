using EIV_Items.Core;
using EIV_Items.Extensions;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a gun mod.
/// </summary>
[EIV_Packable]
public partial class GunMod : CoreItem, ICompatible
{
    /// <inheritdoc />
    public override string ItemType { get; init; } = nameof(GunMod);

    /// <summary>
    /// Gets the collection of guns this mod support.
    /// </summary>
    public Collection<string> GunSupport { get; init; } = [];

    /// <summary>
    /// Gets the collection of tags that the gun must have.
    /// </summary>
    public Collection<string> RequiredGunTags { get; init; } = [];

    /// <inheritdoc />
    public bool IsCompatible(CoreItem item)
    {
        if (item is not Gun gun)
        {
            return false;
        }

        return ICompatibleExtensions.CommpatibleIfEmpty(GunSupport, gun.Id) && ICompatibleExtensions.CompatibleTag(RequiredGunTags, gun);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (GunSupport.Count != 0)
        {
            hash += (int)GunSupport.Average(HashCodeExtensions.StringHashFunction);
        }

        if (RequiredGunTags.Count != 0)
        {
            hash += (int)RequiredGunTags.Average(HashCodeExtensions.StringHashFunction);
        }

        return hash;
    }
}
