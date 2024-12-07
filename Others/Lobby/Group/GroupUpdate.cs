namespace EIV_JsonLib.Lobby.Group;

public class GroupUpdate
{
    public required int GroupId { get; set; }
    public string Owner { get; set; } = string.Empty;
    public List<string> Players { get; set; } = [];
    public bool EnableUserInvites { get; set; }
}
