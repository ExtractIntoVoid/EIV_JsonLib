using System.Text;
using EIV_JsonLib.Classes;
using EIV_JsonLib.Defaults;
using EIV_JsonLib.Interfaces;
using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonLib.Formatters;

public class HealingFormatter : IMessagePackFormatter<IHealing>
{
    public IHealing Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        DefaultHealing @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        string? str = null;
        int arrayLen = 0;
        int count = reader.ReadArrayHeader();
        if (count != (6 + 4))
        {
            Console.WriteLine($"WARN Readed header should be {6 + 34} instead of {count}!");
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
                    @default.CanUse = reader.ReadBoolean();
                    break;
                case 7:
                    @default.UseTime = (decimal)reader.ReadDouble();
                    break;
                case 8:
                    @default.HealAmount = reader.ReadInt32();
                    break;
                case 9:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        SideEffect sideEffect = options.Resolver.GetFormatterWithVerify<SideEffect>().Deserialize(ref reader, options);
                        @default.SideEffects.Add(sideEffect);
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

    public void Serialize(ref MessagePackWriter writer, IHealing value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new DefaultHealing())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 6 + 4 );

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
        writer.Write(value.CanUse);
        writer.Write((double)value.UseTime);
        writer.Write(value.HealAmount);
        writer.WriteArrayHeader(value.SideEffects.Count);
        foreach (var item in value.SideEffects)
        {
            options.Resolver.GetFormatterWithVerify<SideEffect>().Serialize(ref writer, item, options);
        }

        writer.Flush();
    }
}
