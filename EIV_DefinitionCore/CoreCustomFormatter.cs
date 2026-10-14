using EIV_Pack;
using EIV_Pack.Formatters;

/// <summary>
/// Custom formetters writing desired subtypes of the type.
/// </summary>
/// <typeparam name="T">Any type.</typeparam>
public class CoreCustomFormatter<T> : BaseFormatter<T>
{
    /// <summary>
    /// Type to tag map to easily be identify.
    /// </summary>
    private readonly Dictionary<Type, int> typeToTag = [];

    /// <summary>
    /// Gets the last available tag to register a new type.
    /// </summary>
    public int LastAvailable => typeToTag.Count == 0 ? 0 : typeToTag.Last().Value;

    /// <summary>
    /// Adds type to the formatter.
    /// </summary>
    /// <typeparam name="TTypeToAdd">Any type.</typeparam>
    public void AddToTag<TTypeToAdd>()
    {
        Type type = typeof(TTypeToAdd);
        if (typeToTag.ContainsKey(type))
        {
            return;
        }

        int tag = LastAvailable == 0 ? 0 : LastAvailable + 1;
        typeToTag.Add(type, tag);
        FormatterProvider.RegisterCollection<TTypeToAdd>();
    }

    /// <inheritdoc/>
    public override void Deserialize(ref PackReader reader, scoped ref T? value)
    {
        if (!reader.TryReadHeader(out int tag) || tag == Constants.NullHeader)
        {
            value = default;
            return;
        }

        var type = typeToTag.FirstOrDefault(x => x.Value == tag);
        if (type.Value != tag)
        {
            throw new PackException($"Tag not found in the Tag Cache! {tag} {typeof(T)}");
        }
        else
        {
            var oValue = (object?)value;
            FormatterProvider.GetFormatter(type.Key).Deserialize(ref reader, ref oValue);
            value = (T?)oValue;
        }
    }

    /// <inheritdoc/>
    public override void Serialize(ref PackWriter writer, scoped ref readonly T? value)
    {
        if (value == null)
        {
            writer.WriteHeader();
            return;
        }

        Type type = value.GetType();
        if (!typeToTag.TryGetValue(type, out int tag))
        {
            var assignable = typeToTag.Keys.Where(x => x.IsAssignableFrom(type) || type.IsAssignableFrom(x)).ToList();
            foreach (var assignType in assignable)
            {
                if (typeToTag.TryGetValue(assignType, out tag))
                {
                    type = assignType;
                    goto WRITE;
                }
            }

            throw new PackException($"Tag not found in the Tag Cache! {tag} {typeof(T)} {value.GetType()}");
        }

    WRITE:
        writer.WriteHeader(tag);
        var formatter = FormatterProvider.GetFormatter(type);
        var oValue = (object?)value;
        formatter.Serialize(ref writer, ref oValue);
    }
}
