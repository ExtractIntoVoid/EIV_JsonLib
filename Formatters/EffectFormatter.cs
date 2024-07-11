using EIV_JsonLib.Classes;
using EIV_JsonLib.Defaults;
using EIV_JsonLib.Interfaces;
using MessagePack;
using MessagePack.Formatters;
using Newtonsoft.Json.Linq;
using System.Text;

namespace EIV_JsonMP.Formatters;

public class EffectFormatter : IMessagePackFormatter<IEffect>
{
    public IEffect Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        DefaultEffect @default = new();
        if (reader.TryReadNil())
        {
            return @default;
        }
        options.Security.DepthStep(ref reader);

        string? str = null;
        int arrayLen = 0;
        int count = reader.ReadArrayHeader();
        if (count != (8))
        {
            Console.WriteLine($"WARN Readed header should be {8} instead of {count}!");
            return @default;
        }
            
        for (int i = 0; i < count; i++)
        {
            switch (i)
            {
                case 0:
                    str = reader.ReadString();
                    if (str != null)
                        @default.EffectID = str;
                    break;
                case 1:
                    @default.EffectType = (EffectType)reader.ReadByte();
                    break;
                case 2:
                    @default.Health = options.Resolver.GetFormatterWithVerify<HealthEffect>().Deserialize(ref reader, options);
                    break;
                case 3:
                    @default.Energy = options.Resolver.GetFormatterWithVerify<BaseNPEffect>().Deserialize(ref reader, options);
                    break;
                case 4:
                    @default.Time = options.Resolver.GetFormatterWithVerify<TimeEffect>().Deserialize(ref reader, options);
                    break;
                case 5:
                    @default.Strength = options.Resolver.GetFormatterWithVerify<StrengthEffect>().Deserialize(ref reader, options);
                    break;
                case 6:
                    arrayLen = reader.ReadArrayHeader();
                    for (int j = 0; j < arrayLen; j++)
                    {
                        str = reader.ReadString();
                        if (str != null)
                            @default.AppliedFrom.Add(str);
                    }
                    break;
                case 7:
                    str = reader.ReadString();
                    if (str != null)
                        @default.UseClass = str;
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }
        reader.Depth--;
        return @default;
    }

    public void Serialize(ref MessagePackWriter writer, IEffect value, MessagePackSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNil();
            return;
        }

        if (value == new DefaultArmor())
        {
            writer.WriteNil();
            return;
        }

        writer.WriteArrayHeader( 8 );

        // Basic Item
        writer.WriteString(Encoding.UTF8.GetBytes(value.EffectID));
        writer.Write((byte)value.EffectType);

        options.Resolver.GetFormatterWithVerify<HealthEffect>().Serialize(ref writer, value.Health, options);
        options.Resolver.GetFormatterWithVerify<BaseNPEffect>().Serialize(ref writer, value.Energy, options);
        options.Resolver.GetFormatterWithVerify<TimeEffect>().Serialize(ref writer, value.Time, options);
        options.Resolver.GetFormatterWithVerify<StrengthEffect>().Serialize(ref writer, value.Strength, options);

        writer.WriteArrayHeader(value.AppliedFrom.Count);
        foreach (var item in value.AppliedFrom)
        {
            writer.WriteString(Encoding.UTF8.GetBytes(item));
        }

        writer.WriteString(Encoding.UTF8.GetBytes(value.UseClass));

        writer.Flush();
    }
}
