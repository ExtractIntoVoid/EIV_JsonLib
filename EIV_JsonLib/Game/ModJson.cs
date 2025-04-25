using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Game;

/// <summary>
/// Mod.json file schema
/// </summary>
public class ModJson : IEquatable<ModJson>, IEqualityComparer<ModJson>
{
    /// <summary>
    /// The Name of the Mod
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Internal name of the Mod (For loading .dll and .eivp files)
    /// </summary>
    public string InternalName { get; set; } = string.Empty;
    /// <summary>
    /// Authors, those who made the Mod.
    /// </summary>
    public string Authors { get; set; } = string.Empty;
    /// <summary>
    /// Version of the Mod. Please use Semantic Versioning!
    /// </summary>
    public string Version { get; set; } = string.Empty;
    /// <summary>
    /// Other Mod Dependencies (if exists) for the Mod. 
    /// <br>Key must be <see cref="InternalName"/>. Value must be the <see cref="Version"/>.</br>
    /// <br>Dont use it for C# Dependencies. (Such as EIV_Game, etc.)</br>
    /// </summary>
    public Dictionary<string, string> Dependencies { get; set; } = [];

    public bool Equals(ModJson? other)
    {
        if (other == null)
            return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    public bool Equals(ModJson? x, ModJson? y)
    {
        if (x == null && y == null)
            return true;
        if (x == null)
            return false;
        if (y == null)
            return false;
        return x.GetHashCode() == y.GetHashCode();
    }

    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(Name))
            hash += Name.GetHashCode();
        if (!string.IsNullOrEmpty(InternalName))
            hash += InternalName.GetHashCode();
        if (!string.IsNullOrEmpty(Authors))
            hash += Authors.GetHashCode();
        if (!string.IsNullOrEmpty(Version))
            hash += Version.GetHashCode();
        if (Dependencies.Count != 0)
            hash += (int)Dependencies.Select(x => x.Key.GetHashCode() ^ x.Value.GetHashCode()).Average();
        return hash;
    }

    public int GetHashCode([DisallowNull] ModJson obj)
    {
        return obj.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ModJson);
    }
}
