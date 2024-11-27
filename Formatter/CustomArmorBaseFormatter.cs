using EIV_JsonLib.Base;
using MemoryPack;
using MemoryPack.Internal;

namespace EIV_JsonLib.Formatter;

[Preserve]
public class CustomArmorBaseFormatter : MemoryPackFormatter<ArmorBase>
{
    public static Dictionary<Type, ushort> TypeToTag = new()
    {
        { typeof(Rig), 0 },
        { typeof(Helmet), 1 },
        { typeof(Vest), 2 },
    };

    [Preserve]
    public override void Deserialize(ref MemoryPackReader reader, scoped ref ArmorBase? value)
    {
        ushort tag;
        if (!reader.TryReadUnionHeader(out tag))
        {
            value = null;
        }
        else
        {
            var type = TypeToTag.FirstOrDefault(x => x.Value == tag);
            if (type.Value != tag)
                MemoryPackSerializationException.ThrowInvalidTag(tag, typeof(ArmorBase));
            else
            {
                var oValue = (object?)value;
                reader.GetFormatter(type.Key).Deserialize(ref reader, ref oValue);
                value = (ArmorBase?)oValue;
            }
        }
    }

    [Preserve]
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref ArmorBase? value)
    {
        if (value == null)
        {
            writer.WriteNullUnionHeader();
        }
        else
        {
            bool Success = TypeToTag.TryGetValue(value.GetType(), out ushort tag);
            if (!Success)
            {
                MemoryPackSerializationException.ThrowNotFoundInUnionType(value.GetType(), typeof(ArmorBase));
            }
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
