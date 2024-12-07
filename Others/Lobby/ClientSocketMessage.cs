namespace EIV_JsonLib.Lobby;

public class ClientSocketMessage
{
    public required ClientSocketEnum Enum { get; set; }
    public required string JsonMessage { get; set; }
    public string CustomMessageType { get; set; } = string.Empty;
}
