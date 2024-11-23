using EIV_JsonLib.Classes;
using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonLib.Formatters.MiniFormatters;

public class SideEffectFormatter : IMessagePackFormatter<SideEffect>
{
    public SideEffect Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        SideEffect @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        int count = reader.ReadArrayHeader();
        if (count != (3))
        {
            Console.WriteLine($"WARN Readed header should be {3} instead of {count}!");
            return @default;
        }
            
        for (int i = 0; i < count; i++)
        {
            switch (i)
            {
                case 0:
                    var str = reader.ReadString();
                    if (str != null)
                        @default.EffectName = str;
                    break;
                case 1:
                    @default.EffectTime = reader.ReadInt32();
                    break;
                case 2:
                    @default.EffectStrength = reader.ReadInt32();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        reader.Depth--;
        return @default;
    }

    public void Serialize(ref MessagePackWriter writer, SideEffect value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new SideEffect())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 3 );

        // Basic Item
        writer.Write(value.EffectName);
        writer.Write(value.EffectTime);
        writer.Write(value.EffectStrength);

        writer.Flush();
    }
}
