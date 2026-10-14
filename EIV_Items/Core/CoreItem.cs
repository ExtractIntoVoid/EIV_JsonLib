using EIV_Items.Extensions;
using EIV_Pack;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace EIV_Items.Core;

/// <summary>
/// Represent a Core Item.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = DiscriminatorName)]
public abstract partial class CoreItem : ICloneable, IEquatable<CoreItem>, IEqualityComparer<CoreItem>
{
    /// <summary>
    /// The name for json discriminator.
    /// </summary>
    public const string DiscriminatorName = "ClassType";

    /// <summary>
    /// Gets the unique id / name for the item.
    /// </summary>
    public string Id { get; init; } = string.Empty;

    /// <summary>
    /// Gets the type of the item.
    /// </summary>
    /// <remarks>
    /// Declaring please use <see langword="nameof"/>.
    /// </remarks>
    [JsonIgnore]
    [EIV_PackIgnore]
    public abstract string ItemType { get; init; }

    /// <summary>
    /// Gets the weight of the item. How heavy is it.
    /// </summary>
    /// <remarks>
    /// Unit is KG [Kilogramm].
    /// </remarks>
    public double Weight { get; init; }

    /// <summary>
    /// Gets the volume of the item. How much space does it need.
    /// </summary>
    /// <remarks>
    /// Unit is L [Liter].
    /// </remarks>
    public double Volume { get; init; }

    /// <summary>
    /// Gets the tags for the item.
    /// </summary>
    /// <remarks>
    /// Many items check with Tags. You can use this system.
    /// </remarks>
    public Collection<string> Tags { get; init; } = [];

    /// <inheritdoc/>
    public object Clone()
    {
        return MemberwiseClone();
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{Id} {ItemType} {Weight} {Volume} Tags: {string.Join(", ", Tags)}";
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        return obj.GetHashCode() == GetHashCode();
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Id))
        {
            hash += HashCodeExtensions.Hash(Id);
        }

        if (!string.IsNullOrEmpty(ItemType))
        {
            hash += HashCodeExtensions.Hash(ItemType);
        }

        hash += Weight.GetHashCode();
        hash += Volume.GetHashCode();
        if (Tags.Count != 0)
        {
            hash += (int)Tags.Average(HashCodeExtensions.StringHashFunction);
        }

        return hash;
    }

    /// <inheritdoc/>
    public bool Equals(CoreItem? other)
    {
        if (other == null)
        {
            return false;
        }

        return GetHashCode() == other.GetHashCode();
    }

    /// <inheritdoc/>
    public bool Equals(CoreItem? x, CoreItem? y)
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
    public int GetHashCode([DisallowNull] CoreItem obj)
    {
        if (obj == null)
        {
            return 0;
        }

        return obj.GetHashCode();
    }
}