using EIV_JsonLib.Base;
using EIV_Pack;
using EIV_Pack.Formatters;

namespace EIV_JsonLib.Formatter;

/// <summary>
/// Custom formetters writing desired subtypes of the type.
/// </summary>
/// <typeparam name="T">Any type.</typeparam>
public class CustomFormatter<T> : BaseFormatter<T>
{
    /// <summary>
    /// Type to tag map to easily be identify.
    /// </summary>
    public Dictionary<Type, int> TypeToTag = [];

    /// <summary>
    /// Last available tag to register a new type.
    /// </summary>
    public int LastAvailable => TypeToTag.Count == 0 ? 0 : TypeToTag.Last().Value;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TTypeToAdd"></typeparam>
    public void AddToTag<TTypeToAdd>()
    {
        Type type = typeof(TTypeToAdd);
        if (TypeToTag.ContainsKey(type))
            return;
        int tag = LastAvailable == 0 ? 0 : LastAvailable + 1;
        TypeToTag.Add(type, tag);
        FormatterProvider.RegisterCollection<TTypeToAdd>();
    }

    /// <inheritdoc/>
    public override void Deserialize(ref PackReader reader, scoped ref T? value)
    {
        if (!reader.TryReadHeader(out int tag) || tag == EIV_Pack.Constants.NullHeader)
        {
            value = default;
            return;
        }

        var type = TypeToTag.FirstOrDefault(x => x.Value == tag);
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
        if (!TypeToTag.TryGetValue(type, out int tag))
        {
            var assignable = TypeToTag.Keys.Where(x => x.IsAssignableFrom(type) || type.IsAssignableFrom(x)).ToList();
            foreach (var assignType in assignable)
            {
                if (TypeToTag.TryGetValue(assignType, out tag))
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
