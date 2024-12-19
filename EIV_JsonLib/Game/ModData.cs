using System.Diagnostics.CodeAnalysis;

namespace EIV_JsonLib.Game;

/// <summary>
/// Mod Data object
/// </summary>
public class ModData : IEquatable<ModData>, IEqualityComparer<ModData>
{
    /// <summary>
    /// Name of the C# Assembly
    /// </summary>
    public string AssemblyName { get; set; } = string.Empty;
    /// <summary>
    /// Name of the Resource Pack file (.pck)
    /// </summary>
    public string ResourcePack { get; set; } = string.Empty;
    /// <summary>
    /// The mod.json file parsed.
    /// </summary>
    public ModJson ModJson { get; set; } = new();
    /// <summary>
    /// Hashes for the files.
    /// </summary>
    public Dictionary<string, string> Hashes { get; set; } = [];

    public bool Equals(ModData? other)
    {
        if (other == null)
            return false;
        return this.GetHashCode() == other.GetHashCode();
    }

    public bool Equals(ModData? x, ModData? y)
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
        if (!string.IsNullOrEmpty(AssemblyName))
            hash += AssemblyName.GetHashCode();
        if (!string.IsNullOrEmpty(ResourcePack))
            hash += ResourcePack.GetHashCode();
        if (ModJson != null)
            hash += ModJson.GetHashCode();
        if (Hashes.Count != 0)
            hash += (int)Hashes.Select(x => x.Key.GetHashCode() ^ x.Value.GetHashCode()).Average();
        return hash;
    }

    public int GetHashCode([DisallowNull] ModData obj)
    {
        return obj.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ModData);
    }
}
