using EIV_JsonLib.Base;
using EIV_Pack;
using EIV_Pack.Formatters;

namespace EIV_JsonLib.Formatter;

public class CustomFormatter<T> : BaseFormatter<T>
{
    public Dictionary<Type, int> TypeToTag = [];
    public int LastTag => TypeToTag.Count == 0 ? 0 : TypeToTag.Last().Value;
    public int LastAvailable => TypeToTag.Count == 0 ? 0 : TypeToTag.Last().Value + 1;

    public void AddToTag<TTypeToAdd>()
    {
        Type type = typeof(TTypeToAdd);
        if (TypeToTag.ContainsKey(type))
            return;

        TypeToTag.Add(type, LastAvailable);
        FormatterProvider.RegisterCollection<TTypeToAdd>();
    }

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
