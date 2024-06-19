using EIV_JsonLib.DefaultItems;
using EIV_JsonLib.Interfaces;
using MessagePack;
using MessagePack.Formatters;
using System.Text;

namespace EIV_JsonMP.Formatters;

public class StashFormatter : IMessagePackFormatter<IStash>
{
    public IStash Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        DefaultStash @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        string? str = null;
        int arrayLen = 0;
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
                    @default.MaxSize = reader.ReadUInt32();
                    break;
                case 1:
                    @default.MaxWeight = reader.ReadUInt32();
                    break;
                case 2:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.Items.Add(str);
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

    public void Serialize(ref MessagePackWriter writer, IStash value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new DefaultStash())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 3 );

        // Basic Item
        writer.Write(value.MaxSize);
        writer.Write(value.MaxWeight);
        writer.WriteArrayHeader(value.Items.Count);
        foreach (var item in value.Items)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }

        writer.Flush();
    }
}
