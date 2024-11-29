using System.Text.Json.Serialization;

namespace EIV_JsonLib;

public class ServerInfoJson
{
    [JsonIgnore]
    public DateTimeOffset LastHeartBeat;
    public GameServerInfo GameServerInfo { get; set; } = new();
    public List<ModInfo> Mods { get; set; } = [];
    public GameInfo Game { get; set; } = new();
    public LobbyInfo Server { get; set; } = new();
}

/// <summary>
/// Basic Info contains about the Game Server.
/// </summary>
public class GameServerInfo
{
    [JsonRequired]
    public string ServerAddress { get; set; } = string.Empty;

    [JsonRequired]
    public int ServerPort { get; set; } = 0;

    public override string ToString()
    {
        return $"{ServerAddress}:{ServerPort}";
    }
}

/// <summary>
/// Basic Info contains about the Lobby Server.
/// </summary>
public class LobbyInfo
{
    [JsonRequired]
    public string ServerName { get; set; } = string.Empty;

    [JsonRequired]
    public string ServerDescription { get; set; } = string.Empty;
}

public class GameInfo
{
    [JsonRequired]
    public string Version { get; set; } = string.Empty;
    public List<string> AvailableMaps { get; set; } = [];
    public int PlayerNumbers { get; set; } = 0;
    public int MaxPlayerNumbers { get; set; } = 0;
}

public class ModInfo
{
    public string ModName { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Hash { get; set; } = string.Empty;
}