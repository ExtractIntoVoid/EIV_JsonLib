namespace EIV_JsonLib.Lobby;

public class MatchmakeCheck
{
    public string Map { get; set; } = string.Empty;
}

public class GameStart
{
    public string Address { get; set; } = string.Empty;
    public int Port { get; set; } = 0;
}