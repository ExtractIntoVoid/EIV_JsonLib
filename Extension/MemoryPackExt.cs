using MemoryPack;

namespace EIV_JsonLib.Extension;

public static class MemoryPackExt
{
    public static byte[] Serialize<T>(this T item)
    {
        if (!MemoryPackFormatterProvider.IsRegistered<T>())
            return Array.Empty<byte>();
        return MemoryPackSerializer.Serialize(item);
    }

    public static T? Deserialize<T>(this byte[] bytes)
    {
        if (!MemoryPackFormatterProvider.IsRegistered<T>())
            return default;
        return MemoryPackSerializer.Deserialize<T>(bytes);
    }
}
