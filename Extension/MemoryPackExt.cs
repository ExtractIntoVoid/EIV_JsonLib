using MemoryPack;

namespace EIV_JsonLib.Extension;

public static class MemoryPackExt
{
    public static byte[] Serialize<T>(this T item) where T : IMemoryPackable<T>
    {
        return MemoryPackSerializer.Serialize(item);
    }

    public static T? Deserialize<T>(this byte[] bytes) where T : IMemoryPackable<T>
    {
        return MemoryPackSerializer.Deserialize<T>(bytes);
    }
}
