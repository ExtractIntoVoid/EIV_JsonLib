namespace EIV_Items.Lobby;

public class ClientSocketResponse
{
    public bool IsSuccess { get; set; }
    public int ErrorCode { get; set; }
    public string Message { get; set; } = string.Empty;
}
