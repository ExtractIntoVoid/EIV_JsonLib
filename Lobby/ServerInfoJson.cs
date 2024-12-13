using System.Text.Json.Serialization;

namespace EIV_JsonLib;

public class ServerInfoJson
{
    [JsonIgnore]
    public DateTimeOffset LastHeartBeat;
    public List<ModInfo> Mods { get; set; } = [];
    public GameInfo Game { get; set; } = new();
    public LobbyInfo LobbyInfo { get; set; } = new();
}


/// <summary>
/// Basic Info contains about the Lobby Server.
/// </summary>
public class LobbyInfo
{
    /// <summary>
    /// The name of your lobby server.
    /// </summary>
    [JsonRequired]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// A short description to display in the lobby selection
    /// </summary>
    [JsonRequired]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Long Description, can contain BBCode.
    /// </summary>
    [JsonRequired]
    public string LongDescription { get; set; } = string.Empty;

    /// <summary>
    /// Current Player numbers in the lobby.
    /// </summary>
    [JsonRequired]
    public int PlayerNumbers { get; set; } = 0;

    /// <summary>
    /// Max player number the Lobby can handle.
    /// </summary>
    [JsonRequired]
    public int MaxPlayerNumbers { get; set; } = 0;
}

public class GameInfo
{
    /// <summary>
    /// Game version
    /// </summary>
    [JsonRequired]
    public string Version { get; set; } = string.Empty;
    
    /// <summary>
    /// Maps available in the game to choose from.
    /// </summary>
    public List<string> AvailableMaps { get; set; } = [];
}

/// <summary>
/// Only shown are C# Mods, 
/// </summary>
public class ModInfo
{
    public string ModName { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Hash { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
}