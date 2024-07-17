using EIV_JsonLib.Interfaces;
using EIV_JsonMP;
using MessagePack;

namespace EIV_JsonLib.Convert;

public static class MPConvertHelper
{
    public static byte[] Serialize<T>(T item) where T : IItem
    {
        var options = MessagePackSerializerOptions.Standard.WithResolver(JsonMPResolver.Instance);
        return MessagePackSerializer.Serialize(item, options);
    }

    public static T Deserialize<T>(byte[] bytes) where T : IItem
    {
        var options = MessagePackSerializerOptions.Standard.WithResolver(JsonMPResolver.Instance);
        return MessagePackSerializer.Deserialize<T>(bytes, options);
    }
}
