using EIV_Pack;
using EIV_Pack.Formatters;

namespace EIV_JsonLib.Extension;

/// <summary>
/// EIV Pack Extension.
/// </summary>
public static class EIVPackExt
{
    /// <summary>
    /// Serialize this item to bytes.
    /// </summary>
    /// <typeparam name="T">Any <see cref="IPackable{T}"/> type.</typeparam>
    /// <param name="item">The item.</param>
    /// <returns>The byte array.</returns>
    public static byte[] Serialize<T>(this T item) where T : IPackable<T>
    {
        if (!FormatterProvider.IsRegistered<T>())
            return Array.Empty<byte>();
        return Serializer.Serialize(item);
    }

    /// <summary>
    /// Deserialize bytes to item.
    /// </summary>
    /// <typeparam name="T">Any <see cref="IPackable{T}"/> type.</typeparam>
    /// <param name="bytes">The serialized data.</param>
    /// <returns>The deserialized item.</returns>
    public static T? Deserialize<T>(this byte[] bytes) where T : IPackable<T>
    {
        if (!FormatterProvider.IsRegistered<T>())
            return default;
        return Serializer.Deserialize<T>(bytes);
    }
}
