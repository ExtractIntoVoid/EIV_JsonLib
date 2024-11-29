namespace EIV_JsonLib.Lobby;

public class ClientSocketMessage
{
    public required ClientSocketEnum Enum { get; set; }
    public string JsonMessage { get; set; } = string.Empty;
}
