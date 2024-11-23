using EIV_JsonLib.Classes;
using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonLib.Formatters.MiniFormatters;

public class TimeEffectFormatter : IMessagePackFormatter<TimeEffect>
{
    public TimeEffect Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        TimeEffect @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        int count = reader.ReadArrayHeader();
        if (count != (4))
        {
            Console.WriteLine($"WARN Readed header should be {4} instead of {count}!");
            return @default;
        }
            
        for (int i = 0; i < count; i++)
        {
            switch (i)
            {
                case 0:
                    @default.Initial = reader.ReadDouble();
                    break;
                case 1:
                    @default.Min = reader.ReadDouble();
                    break;
                case 2:
                    @default.Max = reader.ReadDouble();
                    break;
                case 3:
                    @default.WaitUntilApply = reader.ReadDouble();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        reader.Depth--;
        return @default;
    }

    public void Serialize(ref MessagePackWriter writer, TimeEffect value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new TimeEffect())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 4 );

        // Basic Item
        writer.Write(value.Initial);
        writer.Write(value.Min);
        writer.Write(value.Max);
        writer.Write(value.WaitUntilApply);

        writer.Flush();
    }
}
