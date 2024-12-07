namespace EIV_JsonLib.Game;

public class ModData
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
}
