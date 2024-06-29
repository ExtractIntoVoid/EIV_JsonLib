using EIV_JsonLib.Classes;
using MessagePack;
using MessagePack.Formatters;
using System.Text;

namespace EIV_JsonMP.Formatters;

public class StrengthEffectFormatter : IMessagePackFormatter<StrengthEffect>
{
    public StrengthEffect Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        StrengthEffect @default = new();
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
                    @default.Min = reader.ReadInt32();
                    break;
                case 1:
                    @default.Max = reader.ReadInt32();
                    break;
                case 2:
                    var arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        var str = reader.ReadString();
                        if (str != null)
                            @default.ApplyTo.Add(str);
                    }
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        reader.Depth--;
        return @default;
    }

    public void Serialize(ref MessagePackWriter writer, StrengthEffect value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new StrengthEffect())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 3 );

        // Basic Item
        writer.Write(value.Min);
        writer.Write(value.Max);
        writer.WriteArrayHeader(value.ApplyTo.Count);
        foreach (var item in value.ApplyTo)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }

        writer.Flush();
    }
}
