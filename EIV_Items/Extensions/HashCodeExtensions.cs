using EIV_Items.Core;

namespace EIV_Items.Extensions;

/// <summary>
/// Provides an extension for <see cref="object.GetHashCode"/>.
/// </summary>
public static class HashCodeExtensions
{
    /// <summary>
    /// Static function for getting <see cref="object.GetHashCode"/> from <see langword="string"/>.
    /// </summary>
    public static readonly Func<string, int> StringHashFunction = new(Hash);

    /// <inheritdoc cref="object.GetHashCode"/>
    public static int Hash<T>(this T item)
        where T : CoreItem
    {
        if (item == null)
        {
            return 0;
        }

        return item.GetHashCode();
    }

    /// <inheritdoc cref="object.GetHashCode"/>
    public static int Hash(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }

#if !NETSTANDARD2_0
        return str.GetHashCode(StringComparison.InvariantCultureIgnoreCase);
#else
        return str.GetHashCode();
#endif
    }
}
