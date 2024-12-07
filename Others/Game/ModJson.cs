namespace EIV_JsonLib.Game;

public class ModJson
{
    /// <summary>
    /// The Name of the Mod
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Internal name of the Mod (For loading .dll and .pck files)
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
    // Internal Name | Version (* if you dont care about it) - WITH EIV.
    // For C# Dependencies just drop those into /Mods/Dependencies folder.
    /// <summary>
    /// Other Mod Dependencies (if exists) for the Mod. 
    /// <br>Key must be <see cref="InternalName"/>. Value must be the <see cref="Version"/>.</br>
    /// <br>Dont use it for C# Dependencies. (Such as ModAPI, EIV_Game, etc.)</br>
    /// </summary>
    public Dictionary<string, string> Dependencies { get; set; } = [];
}
