using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

/// <summary>
/// Provides a resolvers and a default settings for json serializer options.
/// </summary>
public static class JsonSerializerConvert
{
    /// <summary>
    /// Gets the <see cref="PolymorphismRegistry"/>'s.
    /// </summary>
    public static HashSet<PolymorphismRegistry> Polymorphisms { get; } = [];

    /// <summary>
    /// Gets the type info resolvers.
    /// </summary>
    public static HashSet<IJsonTypeInfoResolver> Resolvers { get; } = [];

    /// <summary>
    /// Get the default serialzier options with all <see cref="Resolvers"/>.
    /// </summary>
    /// <param name="indent">Should indent the json.</param>
    /// <returns>The serializer options.</returns>
    public static JsonSerializerOptions GetSerializerSettings(bool indent = true)
    {
        JsonSerializerOptions jsonSerializerSettings = new()
        {
            WriteIndented = indent,
            TypeInfoResolverChain = { },
        };

        foreach (var item in Resolvers)
        {
            if (item == null)
            {
                continue;
            }

            jsonSerializerSettings.TypeInfoResolverChain.Add(item);
        }

        jsonSerializerSettings.TypeInfoResolver = JsonTypeInfoResolver.Combine([.. jsonSerializerSettings.TypeInfoResolverChain])
            .WithAddedModifier(typeInfo =>
        {
            foreach (var item in Polymorphisms)
            {
                if (item == null)
                {
                    continue;
                }

                item.AddPolymorphism(typeInfo);
            }
        });

        return jsonSerializerSettings;
    }

    /// <summary>
    /// Gets the type info.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The type info.</returns>
    public static JsonTypeInfo? GetTypeInfo([NotNull] Type type)
    {
        JsonSerializerOptions options = GetSerializerSettings();
        return options.GetTypeInfo(type);
    }

    /// <summary>
    /// Tries to get the type info.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="typeInfo">The type info.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public static bool TryGetTypeInfo([NotNull] Type type, [NotNullWhen(true)] out JsonTypeInfo? typeInfo)
    {
        JsonSerializerOptions options = GetSerializerSettings();
        typeInfo = options.GetTypeInfo(type);
        return typeInfo != null;
    }

    /// <summary>
    /// Gets the type info.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    /// <returns>The type info.</returns>
    public static JsonTypeInfo<T>? GetTypeInfo<T>()
    {
        JsonSerializerOptions options = GetSerializerSettings();
        return options.GetTypeInfo(typeof(T)) as JsonTypeInfo<T>;
    }

    /// <summary>
    /// Tries to get the type info.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    /// <param name="type">The type.</param>
    /// <param name="typeInfo">The type info.</param>
    /// <returns><see langword="true"/> if success; otherwise <see langword="false"/>.</returns>
    public static bool TryGetTypeInfo<T>([NotNull] Type type, [NotNullWhen(true)] out JsonTypeInfo<T>? typeInfo)
    {
        JsonSerializerOptions options = GetSerializerSettings();
        typeInfo = options.GetTypeInfo(type) as JsonTypeInfo<T>;
        return typeInfo != null;
    }

    /// <summary>
    /// Gets the <paramref name="type"/> name if has any generics in it.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The type name.</returns>
    public static string NameWithGenerics(Type type)
    {
        if (type == null)
        {
            return "null";
        }

        if (type.IsArray)
        {
            return $"{type.GetElementType()?.Name}[]";
        }

        if (!type.IsGenericType)
        {
            return type.Name;
        }

        var name = type.GetGenericTypeDefinition().Name;
#if NET8_0_OR_GREATER
        int index = name.IndexOf('`', StringComparison.InvariantCultureIgnoreCase);
#else
        int index = name.IndexOf('`');
#endif
        var newName = index == -1 ? name : name[..index];

        var list = type.GetGenericArguments().Select(NameWithGenerics).ToList();
        return $"{newName}|{string.Join(",", list)}";
    }
}
