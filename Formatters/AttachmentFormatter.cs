using System.Text;
using EIV_JsonLib.Defaults;
using EIV_JsonLib.Interfaces;
using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonLib.Formatters;

public class AttachmentFormatter : IMessagePackFormatter<IAttachment>
{
    public IAttachment Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        DefaultAttachment @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        string? str = null;
        int arrayLen = 0;
        int count = reader.ReadArrayHeader();
        if (count != (6 + 2))
        {
            Console.WriteLine($"WARN Readed header should be {6 + 2} instead of {count}!");
            return @default;
        }
            
        for (int i = 0; i < count; i++)
        {
            switch (i)
            {
                case 0:
                    str = reader.ReadString();
                    if (str != null)
                        @default.BaseID = str;
                    break;
                case 1:
                    str = reader.ReadString();
                    if (str != null)
                        @default.ItemType = str;
                    break;
                case 2:
                    @default.Weight = (decimal)reader.ReadDouble();
                    break;
                case 3:
                    @default.Volume = (decimal)reader.ReadDouble();
                    break;
                case 4:
                    str = reader.ReadString();
                    if (str != null)
                        @default.AssetPath = str;
                    break;
                case 5:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.Tags.Add(str);
                    }
                    break;
                case 6:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.GunSupport.Add(str);
                    }
                    break;
                case 7:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.RequiredGunTags.Add(str);
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

    public void Serialize(ref MessagePackWriter writer, IAttachment value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new DefaultAttachment())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 6 + 2 );

        // Basic Item
        writer.WriteString(Encoding.UTF8.GetBytes(value.BaseID));
        writer.WriteString(Encoding.UTF8.GetBytes(value.ItemType));
        writer.Write((double)value.Weight);
        writer.Write((double)value.Volume);
        writer.WriteString(Encoding.UTF8.GetBytes(value.AssetPath));

        writer.WriteArrayHeader(value.Tags.Count);
        foreach (var item in value.Tags)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }

        // Additional Data
        writer.WriteArrayHeader(value.GunSupport.Count);
        foreach (var item in value.GunSupport)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }
        writer.WriteArrayHeader(value.RequiredGunTags.Count);
        foreach (var item in value.RequiredGunTags)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }

        writer.Flush();
    }
}
