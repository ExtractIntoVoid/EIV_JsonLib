using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonLib;

public class EIVFormatterResolver : IFormatterResolver
{
    public static readonly IFormatterResolver Instance = new EIVFormatterResolver();
    public IMessagePackFormatter<T>? GetFormatter<T>()
    {
        return FormatterCache<T>.Formatter;
    }

    private static class FormatterCache<T>
    {
        public static readonly IMessagePackFormatter<T>? Formatter;

        static FormatterCache()
        {
            Formatter = (IMessagePackFormatter<T>?)JsonMPFormatters.GetFormatter(typeof(T));
        }
    }
}
