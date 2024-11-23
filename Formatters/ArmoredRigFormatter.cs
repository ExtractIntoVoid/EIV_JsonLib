using System.Text;
using EIV_JsonLib.Defaults;
using EIV_JsonLib.Interfaces;
using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonLib.Formatters;

public class ArmoredRigFormatter : IMessagePackFormatter<IArmoredRig>
{
    public IArmoredRig Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        DefaultArmoredRig @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        string? str = null;
        int arrayLen = 0;
        int count = reader.ReadArrayHeader();
        if (count != (6 + 2 + 2 + 4))
        {
            Console.WriteLine($"WARN Readed header should be {6 + 2 + 2 + 4} instead of {count}!");
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
                    @default.BlockEfficacy = (decimal)reader.ReadDouble();
                    break;
                case 7:
                    @default.ArmorWeight = (decimal)reader.ReadDouble();
                    break;
                case 8:
                    str = reader.ReadString();
                    if (str != null)
                        @default.PlateSlotId = str;
                    break;
                case 9:
                    @default.MaxItem = reader.ReadUInt32();
                    break;
                case 10:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.ItemIds.Add(str);
                    }
                    break;
                case 11:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.ItemTypesAccepted.Add(str);
                    }
                    break;
                case 12:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.SpecificItemsAccepted.Add(str);
                    }
                    break;
                case 13:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.ArmorPlateAccepted.Add(str);
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

    public void Serialize(ref MessagePackWriter writer, IArmoredRig value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new DefaultArmoredRig())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 6 + 2 + 2 + 4 );

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
        writer.Write((double)value.BlockEfficacy);
        writer.Write((double)value.ArmorWeight);

        writer.Write(value.PlateSlotId);
        writer.Write(value.MaxItem);

        writer.WriteArrayHeader(value.ItemIds.Count);
        foreach (var item in value.ItemIds)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }
        writer.WriteArrayHeader(value.ItemTypesAccepted.Count);
        foreach (var item in value.ItemTypesAccepted)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }
        writer.WriteArrayHeader(value.SpecificItemsAccepted.Count);
        foreach (var item in value.SpecificItemsAccepted)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }
        writer.WriteArrayHeader(value.ArmorPlateAccepted.Count);
        foreach (var item in value.ArmorPlateAccepted)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }

        writer.Flush();
    }
}
