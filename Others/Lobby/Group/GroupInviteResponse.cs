namespace EIV_JsonLib.Lobby.Group;

public class GroupInviteResponse
{
    public int GroupId { get; set; }
    public required string Inviter { get; set; }
    public bool IsDenied { get; set; }
}
