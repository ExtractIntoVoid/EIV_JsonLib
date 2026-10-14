using EIV_Items;
using EIV_Items.Extensions;
using EIV_Pack;
using EIV_Profile.ProfileModules;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace EIV_Profile;

/// <summary>
/// Represent a user character.
/// </summary>
[EIV_Packable]
public partial class UserCharacter : IEquatable<UserCharacter>, IEqualityComparer<UserCharacter>
{
    /// <summary>
    /// Gets or sets the name of the character.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the origin of the character.
    /// </summary>
    public string Origin { get; init; } = string.Empty;

    /// <summary>
    /// Gets the creation date of the character.
    /// </summary>
    public DateTimeOffset CreationDate { get; init; } = DateTimeOffset.MinValue;

    /// <summary>
    /// Gets the inventory.
    /// </summary>
    public Inventory Inventory { get; init; } = new();

    /// <summary>
    /// Gets the profile modules.
    /// </summary>
    public Collection<IProfileModule> Modules { get; init; } = [];

    /// <summary>
    /// Gets the character stash.
    /// </summary>
    public Stash Stash { get; } = new();

    /// <summary>
    /// Tries to get profile module.
    /// </summary>
    /// <typeparam name="T">Any <see cref="IProfileModule"/>.</typeparam>
    /// <param name="name">The name of the module.</param>
    /// <param name="out_t">The module.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public bool TryGetProfileModule<T>([NotNull] string name, [NotNullWhen(true)] out T? out_t)
        where T : IProfileModule
    {
        out_t = default;
        out_t = (T?)Modules.FirstOrDefault(x => x is T && x.Name == name);
        return out_t != null;
    }

    /// <summary>
    /// Checks if the module name exists.
    /// </summary>
    /// <param name="name">The name of the module.</param>
    /// <returns><see langword="true"/> if exists; otherwise <see langword="false"/>.</returns>
    public bool IsProfileModuleNameExist([NotNull] string name)
    {
        return Modules.Any(x => x.Name == name);
    }

    /// <inheritdoc/>
    public bool Equals(UserCharacter? other)
    {
        if (other == null)
        {
            return false;
        }

        return other.GetHashCode() == this.GetHashCode();
    }

    /// <inheritdoc/>
    public bool Equals(UserCharacter? x, UserCharacter? y)
    {
        if (x == null && y == null)
        {
            return true;
        }

        if (x == null)
        {
            return false;
        }

        if (y == null)
        {
            return false;
        }

        return x.GetHashCode() == y.GetHashCode();
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Name))
        {
            hash += HashCodeExtensions.Hash(Name);
        }

        if (!string.IsNullOrEmpty(Origin))
        {
            hash += HashCodeExtensions.Hash(Origin);
        }

        hash += CreationDate.GetHashCode();
        if (Inventory != null)
        {
            hash += Inventory.GetHashCode();
        }

        if (Modules.Count != 0)
        {
            hash += (int)Modules.Average(x => x.GetHashCode());
        }

        return hash;
    }

    /// <inheritdoc/>
    public int GetHashCode([DisallowNull] UserCharacter obj)
    {
        if (obj == null)
        {
            return 0;
        }

        return obj.GetHashCode();
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as UserCharacter);
    }
}