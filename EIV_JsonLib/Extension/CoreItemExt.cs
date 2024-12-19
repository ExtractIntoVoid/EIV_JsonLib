using EIV_JsonLib.Base;
using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Extension;

public static partial class CoreItemExt
{
    public static bool Is<T>(this CoreItem item) where T : CoreItem => item is T;

    public static T? As<T>(this CoreItem item) where T : CoreItem => item.Is<T>() ? (T)item : default;

    public static bool HasProperty(this CoreItem item, [DisallowNull] string value) => item.GetType().GetProperty(value) != null;

    public static T? GetProperty<T>(this CoreItem item, [DisallowNull] string value)
    {
        if (!item.HasProperty(value))
            return default;
        if (item.GetType().GetProperty(value)!.PropertyType != typeof(T))
            return default;
        return (T?)item.GetType().GetProperty(value)!.GetValue(item);
    }

    public static bool ChangeProperty(this CoreItem item, [DisallowNull] string valueName, KVChange kv)
    {
        if (!item.HasProperty(valueName))
            return false;
        System.Reflection.PropertyInfo prop = item.GetType().GetProperty(valueName)!;
        if (!prop.CanWrite)
            return false;
        switch (kv.AvailableTypeName)
        {
            case TypeName.String:
                if (prop.PropertyType != typeof(string))
                    return false;
                prop.SetValue(item, kv.StringValue);
                break;
            case TypeName.Int:
                if (prop.PropertyType != typeof(int))
                    return false;
                prop.SetValue(item, kv.IntValue);
                break;
            case TypeName.UInt:
                if (prop.PropertyType != typeof(uint))
                    return false;
                prop.SetValue(item, kv.UIntValue);
                break;
            case TypeName.Decimal:
                if (prop.PropertyType != typeof(decimal))
                    return false;
                prop.SetValue(item, kv.DecimalValue);
                break;
            case TypeName.List_String:
                if (prop.PropertyType != typeof(List<string>))
                    return false;
                prop.SetValue(item, kv.ListStringValue);
                break;
            case TypeName.Double:
                if (prop.PropertyType != typeof(double))
                    return false;
                prop.SetValue(item, kv.DoubleValue);
                break;
            default:
                break;
        }
        return true;
    }
}