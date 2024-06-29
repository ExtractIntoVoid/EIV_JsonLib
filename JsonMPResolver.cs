using MessagePack;
using MessagePack.Formatters;

namespace EIV_JsonMP;

public class JsonMPResolver : IFormatterResolver
{
    public static readonly IFormatterResolver Instance = new JsonMPResolver();
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
