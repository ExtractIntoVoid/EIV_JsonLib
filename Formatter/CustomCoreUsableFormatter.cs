using EIV_JsonLib.Base;
using MemoryPack;
using MemoryPack.Internal;

namespace EIV_JsonLib.Formatter;

[Preserve]
public class CustomCoreUsableFormatter : MemoryPackFormatter<CoreUsable>
{
    public static Dictionary<Type, ushort> TypeToTag = new()
    {
        { typeof(Consumable), 0 },
        { typeof(Throwable), 1 },
        { typeof(Melee), 2 },
        { typeof(Gun), 3 },
        { typeof(Healing), 4 },
    };

    [Preserve]
    public override void Deserialize(ref MemoryPackReader reader, scoped ref CoreUsable? value)
    {
        ushort tag;
        if (!reader.TryReadUnionHeader(out tag))
            value = null;
        else
        {
            var type = TypeToTag.FirstOrDefault(x => x.Value == tag);
            if (type.Value != tag)
                MemoryPackSerializationException.ThrowInvalidTag(tag, typeof(CoreUsable));
            else
            {
                var oValue = (object?)value;
                reader.GetFormatter(type.Key).Deserialize(ref reader, ref oValue);
                value = (CoreUsable?)oValue;
            }
        }
    }

    [Preserve]
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref CoreUsable? value)
    {
        if (value == null)
            writer.WriteNullUnionHeader();
        else
        {
            bool Success = TypeToTag.TryGetValue(value.GetType(), out ushort tag);
            if (!Success)
                MemoryPackSerializationException.ThrowNotFoundInUnionType(value.GetType(), typeof(CoreUsable));
            else
            {
                writer.WriteUnionHeader(tag);
                var formatter = writer.GetFormatter(value.GetType());
                var oValue = (object?)value;
                formatter.Serialize(ref writer, ref oValue);
            }
        }
    }
}
