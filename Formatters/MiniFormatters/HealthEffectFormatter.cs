using EIV_JsonLib.Classes;
using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonMP.Formatters;

public class HealthEffectFormatter : IMessagePackFormatter<HealthEffect>
{
    public HealthEffect Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        HealthEffect @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        int count = reader.ReadArrayHeader();
        if (count != (1))
        {
            Console.WriteLine($"WARN Readed header should be {1} instead of {count}!");
            return @default;
        }
            
        for (int i = 0; i < count; i++)
        {
            switch (i)
            {
                case 0:
                    var str = reader.ReadString();
                    if (str != null)
                        @default.Cause = str;
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        var effect = options.Resolver.GetFormatterWithVerify<BaseNPEffect>().Deserialize(ref reader, options);
        @default.Positive = effect.Positive;
        @default.Negative = effect.Negative;

        reader.Depth--;
        return @default;
    }

    public void Serialize(ref MessagePackWriter writer, HealthEffect value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new HealthEffect())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 1 );

        // Basic Item
        writer.Write(value.Cause);

        options.Resolver.GetFormatterWithVerify<BaseNPEffect>().Serialize( ref writer, value, options );

        writer.Flush();
    }
}
