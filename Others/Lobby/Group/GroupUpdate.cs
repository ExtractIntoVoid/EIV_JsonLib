namespace EIV_JsonLib.Lobby.Group;

public class GroupUpdate
{
    public int GroupId { get; set; }
    public string Owner { get; set; } = string.Empty;
    public List<string> Players { get; set; } = [];
}
