using EIV_JsonLib.Base;
using MemoryPack;
using MemoryPack.Internal;

namespace EIV_JsonLib.Formatter;

[Preserve]
public class CustomCoreItemFormatter : MemoryPackFormatter<CoreItem>
{
    public static Dictionary<Type, ushort> TypeToTag = new()
    {
        { typeof(CoreUsable), 0 },
        { typeof(CoreArmor), 1 },
        // Add more "Base" Like after this

        // Regular items.
        { typeof(Backpack), 2 },
        { typeof(Ammo), 3 },
        { typeof(Magazine), 4 },
        { typeof(GunMod), 5 },
        { typeof(ArmorPlate), 6 },
    };

    public static ushort LastTag => TypeToTag.Last().Value;
    public static ushort LastAvailable => (ushort)(TypeToTag.Last().Value + 1);

    [Preserve]
    public override void Deserialize(ref MemoryPackReader reader, scoped ref CoreItem? value)
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
                MemoryPackSerializationException.ThrowInvalidTag(tag, typeof(CoreItem));
            else
            {
                var oValue = (object?)value;
                reader.GetFormatter(type.Key).Deserialize(ref reader, ref oValue);
                value = (CoreItem?)oValue;
            }
        }        
    }

    [Preserve]
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref CoreItem? value)
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
                MemoryPackSerializationException.ThrowNotFoundInUnionType(value.GetType(), typeof(CoreItem));
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
