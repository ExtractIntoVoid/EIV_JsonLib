using System.Text;
using EIV_JsonLib.Classes;
using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonLib.Formatters;

public class ItemRecreatorFormatter : IMessagePackFormatter<ItemRecreator>
{
    public ItemRecreator Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        ItemRecreator @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        string? str = null;
        int arrayLen = 0;
        int count = reader.ReadArrayHeader();
        if (count != (5))
        {
            Console.WriteLine($"WARN Readed header should be {5} instead of {count}!");
            return @default;
        }
            
        for (int i = 0; i < count; i++)
        {
            switch (i)
            {
                case 0:
                    str = reader.ReadString();
                    if (str != null)
                        @default.ItemBaseID = str;
                    break;
                case 1:
                    @default.Amount = reader.ReadUInt32();
                    break;
                case 2:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        var item = options.Resolver.GetFormatterWithVerify<ItemRecreator>().Deserialize(ref reader, options);
                        if (item != null)
                            @default.Contained.Add(item);
                    }
                    break;
                case 3:
                    @default.Slot = (AcceptedSlots)reader.ReadByte();
                    break;
                case 4:
                    arrayLen = reader.ReadMapHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str == null)
                            continue;

                        ItemRecreator.KVChange kVChange = new();
                        kVChange.AvailableTypeName = (TypeName)reader.ReadByte();

                        if (reader.TryReadNil())
                            continue;
                        switch (kVChange.AvailableTypeName)
                        {
                            case TypeName.String:
                                var str2 = reader.ReadString();
                                if (str2 != null)
                                    kVChange.StringValue = str2;
                                break;
                            case TypeName.Int:
                                kVChange.IntValue = reader.ReadInt32();
                                break;
                            case TypeName.UInt:
                                kVChange.UIntValue = reader.ReadUInt32();
                                break;
                            case TypeName.Decimal:
                                kVChange.DecimalValue = (decimal)reader.ReadDouble();
                                break;
                            case TypeName.List_String:
                                kVChange.ListStringValue = [];
                                int listCount = reader.ReadArrayHeader();
                                for (int x = 0; x < listCount; x++)
                                {
                                    var str3 = reader.ReadString();
                                    if (str3 != null)
                                        kVChange.ListStringValue.Add(str3);
                                }
                                break;
                            default:
                                break;
                        }
                        @default.ChangedValues.Add(str, kVChange);
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

    public void Serialize(ref MessagePackWriter writer, ItemRecreator value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new ItemRecreator())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 5 );

        // Basic Item
        writer.WriteString(Encoding.UTF8.GetBytes(value.ItemBaseID));
        writer.Write(value.Amount);
        writer.WriteArrayHeader(value.Contained.Count);
        foreach (var item in value.Contained)
        {
            options.Resolver.GetFormatterWithVerify<ItemRecreator>().Serialize(ref writer, item, options);
        }
        writer.Write((byte)value.Slot);
        writer.WriteMapHeader(value.ChangedValues.Count);
        foreach (var item in value.ChangedValues)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item.Key));
            
            writer.Write((byte)item.Value.AvailableTypeName);

            switch (item.Value.AvailableTypeName)
            {
                case TypeName.String:
                    writer.Write(item.Value.StringValue);
                    break;
                case TypeName.Int:
                    if (item.Value.IntValue.HasValue)
                        writer.WriteInt32(item.Value.IntValue.Value);
                    else
                        writer.WriteNil();
                    break;
                case TypeName.UInt:
                    if (item.Value.UIntValue.HasValue)
                        writer.WriteUInt32(item.Value.UIntValue.Value);
                    else
                        writer.WriteNil();
                    break;
                case TypeName.Decimal:
                    if (item.Value.DecimalValue.HasValue)
                        writer.Write((double)item.Value.DecimalValue.Value);
                    else
                        writer.WriteNil();
                    break;
                case TypeName.List_String:
                    if (item.Value.ListStringValue != null)
                    {
                        writer.WriteArrayHeader(item.Value.ListStringValue.Count);
                        foreach (string listValue in item.Value.ListStringValue)
                        {
                            writer.WriteString(Encoding.UTF8.GetBytes(listValue));
                        }
                    }
                    else
                        writer.WriteNil();
                    break;
                default:
                    break;
            }
        }

        writer.Flush();
    }
}
