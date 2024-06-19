﻿using EIV_JsonLib.DefaultItems;
using EIV_JsonLib.Interfaces;
using MessagePack;
using MessagePack.Formatters;
using System.Text;

namespace EIV_JsonMP.Formatters;

public class MeleeFormatter : IMessagePackFormatter<IMelee>
{
    public IMelee Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        DefaultMelee @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        string? str = null;
        int arrayLen = 0;
        int count = reader.ReadArrayHeader();
        if (count != (5 + 5))
        {
            Console.WriteLine($"WARN Readed header should be {5 + 5} instead of {count}!");
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
                    str = reader.ReadString();
                    if (str != null)
                        @default.AssetPath = str;
                    break;
                case 4:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.Tags.Add(str);
                    }
                    break;
                case 5:
                    @default.CanUse = reader.ReadBoolean();
                    break;
                case 6:
                    @default.UseTime = (decimal)reader.ReadDouble();
                    break;
                case 7:
                    @default.Damage = reader.ReadUInt32();
                    break;
                case 8:
                    @default.ArmorDamage = reader.ReadUInt32();
                    break;
                case 9:
                    str = reader.ReadString();
                    if (str != null)
                        @default.AssetPath = str;
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }
        reader.Depth--;
        return @default;
    }

    public void Serialize(ref MessagePackWriter writer, IMelee value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new DefaultMelee())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 5 + 5 );

        // Basic Item
        writer.WriteString(Encoding.UTF8.GetBytes(value.BaseID));
        writer.WriteString(Encoding.UTF8.GetBytes(value.ItemType));
        writer.Write((double)value.Weight);
        writer.WriteString(Encoding.UTF8.GetBytes(value.AssetPath));

        writer.WriteArrayHeader(value.Tags.Count);
        foreach (var item in value.Tags)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }
        writer.Write(value.CanUse);
        writer.Write((double)value.UseTime);
        writer.Write(value.Damage);
        writer.Write(value.ArmorDamage);
        writer.Write(value.DamageType);

        writer.Flush();
    }
}
