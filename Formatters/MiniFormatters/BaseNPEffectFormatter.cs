using EIV_JsonLib.Classes;
using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonMP.Formatters;

public class BaseNPEffectFormatter : IMessagePackFormatter<BaseNPEffect>
{
    public BaseNPEffect Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        BaseNPEffect @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        int count = reader.ReadArrayHeader();
        if (count != (2))
        {
            Console.WriteLine($"WARN Readed header should be {2} instead of {count}!");
            return @default;
        }
            
        for (int i = 0; i < count; i++)
        {
            switch (i)
            {
                case 0:
                    @default.Positive = reader.ReadInt32();
                    break;
                case 1:
                    @default.Negative = reader.ReadInt32();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }
        reader.Depth--;
        return @default;
    }

    public void Serialize(ref MessagePackWriter writer, BaseNPEffect value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new BaseNPEffect())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 2 );

        // Basic Item
        writer.Write(value.Positive);
        writer.Write(value.Negative);
        writer.Flush();
    }
}
