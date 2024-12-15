using EIV_JsonLib.Base;
using MemoryPack;
using MemoryPack.Internal;

namespace EIV_JsonLib.Formatter;

[Preserve]
public class CustomCoreArmorFormatter : MemoryPackFormatter<CoreArmor>
{
    public static Dictionary<Type, ushort> TypeToTag = new()
    {
        { typeof(Rig), 0 },
        { typeof(Helmet), 1 },
        { typeof(Vest), 2 },
    };

    [Preserve]
    public override void Deserialize(ref MemoryPackReader reader, scoped ref CoreArmor? value)
    {
        ushort tag;
        if (!reader.TryReadUnionHeader(out tag))
            value = null;
        else
        {
            var type = TypeToTag.FirstOrDefault(x => x.Value == tag);
            if (type.Value != tag)
                MemoryPackSerializationException.ThrowInvalidTag(tag, typeof(CoreArmor));
            else
            {
                var oValue = (object?)value;
                reader.GetFormatter(type.Key).Deserialize(ref reader, ref oValue);
                value = (CoreArmor?)oValue;
            }
        }
    }

    [Preserve]
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref CoreArmor? value)
    {
        if (value == null)
            writer.WriteNullUnionHeader();
        else
        {
            bool Success = TypeToTag.TryGetValue(value.GetType(), out ushort tag);
            if (!Success)
                MemoryPackSerializationException.ThrowNotFoundInUnionType(value.GetType(), typeof(CoreArmor));
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
