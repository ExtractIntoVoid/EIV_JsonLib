using EIV_Items.Core;
using EIV_Items.Interfaces;
using System.Collections.ObjectModel;

namespace EIV_Items.Extensions;

/// <summary>
/// Provides an extension for <see cref="ICompatible"/> items.
/// </summary>
public static class ICompatibleExtensions
{
    /// <summary>
    /// Checks whenever the <paramref name="ids"/> is compatible with <paramref name="id"/>.
    /// </summary>
    /// <param name="ids">The ids to check against it..</param>
    /// <param name="id">The id to check.</param>
    /// <returns><see langword="true"/> if compatible; otherwise <see langword="false"/>.</returns>
    /// <remarks>
    /// When <paramref name="ids"/> is empty it will accept any <paramref name="id"/>.
    /// </remarks>
    public static bool CommpatibleIfEmpty(Collection<string> ids, string id)
    {
        // If null or empty we accept every item!
        if (ids == null || ids.Count == 0)
        {
            return true;
        }

        if (string.IsNullOrEmpty(id))
        {
            return false;
        }

        // alternatively we check if it contains it
        return ids.Contains(id);
    }

    /// <summary>
    /// Checks whenever the <paramref name="item"/>'s tags is compatible with <paramref name="tags"/>.
    /// </summary>
    /// <param name="tags">The tags to check against it..</param>
    /// <param name="item">The item.</param>
    /// <returns><see langword="true"/> if compatible; otherwise <see langword="false"/>.</returns>
    public static bool CompatibleTag(Collection<string> tags, CoreItem item)
    {
        if (item == null)
        {
            return false;
        }

        return tags.Intersect(item.Tags).Any();
    }
}
