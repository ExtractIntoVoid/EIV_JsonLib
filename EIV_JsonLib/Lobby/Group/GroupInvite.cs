namespace EIV_Items.Lobby.Group;

public class GroupInvite
{
    public required int GroupId { get; set; }
    public required string Inviter { get; set; }
    public required string Invitee { get; set; }
}
