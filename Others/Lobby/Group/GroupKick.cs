namespace EIV_JsonLib.Lobby.Group;

public class GroupKick
{
    public int GroupId { get; set; }
    public required string Invitee { get; set; }
    public string Reason { get; set; } = string.Empty;
}
