namespace EIV_Items.Lobby.Group;

public class GroupInviteResponse
{
    public required int GroupId { get; set; }
    public required string Inviter { get; set; }
    public bool IsDenied { get; set; }
}
