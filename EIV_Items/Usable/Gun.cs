using EIV_Items.Core;
using EIV_Items.Extensions;
using EIV_Items.Interfaces;
using EIV_Pack;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace EIV_Items;

/// <summary>
/// Represent a gun.
/// </summary>
[EIV_Packable]
public partial class Gun : CoreUsable, ICompatible
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string ItemType { get; init; } = nameof(Gun);

    /// <summary>
    /// Gets the supported magazines.
    /// </summary>
    public Collection<string> MagazineSupport { get; init; } = [];

    /// <summary>
    /// Gets or sets the stored magazine.
    /// </summary>
    public Magazine? Magazine { get; set; }

    /// <summary>
    /// Gets the stored gun mods.
    /// </summary>
    public Collection<GunMod> GunMods { get; init; } = [];

    /// <inheritdoc/>
    public bool IsCompatible(CoreItem item)
    {
        if (item is not Magazine magazine)
        {
            return false;
        }

        return ICompatibleExtensions.CommpatibleIfEmpty(MagazineSupport, magazine.Id) || ICompatibleExtensions.CompatibleTag(MagazineSupport, magazine);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        if (MagazineSupport.Count != 0)
        {
            hash += (int)MagazineSupport.Average(HashCodeExtensions.StringHashFunction);
        }

        if (Magazine != null)
        {
            hash += Magazine.GetHashCode();
        }

        if (GunMods.Count != 0)
        {
            hash += (int)GunMods.Average(HashCodeExtensions.Hash);
        }

        return hash;
    }
}
