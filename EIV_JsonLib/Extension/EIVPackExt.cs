using EIV_Pack;

namespace EIV_JsonLib.Extension;

public static class EIVPackExt
{
    public static byte[] Serialize<T>(this T item)
    {
        if (!FormatterProvider.IsRegistered<T>())
            return Array.Empty<byte>();
        return Serializer.Serialize(item);
    }

    public static T? Deserialize<T>(this byte[] bytes)
    {
        if (!FormatterProvider.IsRegistered<T>())
            return default;
        return Serializer.Deserialize<T>(bytes);
    }
}
