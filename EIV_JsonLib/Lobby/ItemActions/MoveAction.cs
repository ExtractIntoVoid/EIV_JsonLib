using EIV_Items.Base;

namespace EIV_Items.Lobby.ItemActions;

public class MoveAction
{
    public required CoreItem Item { get; set; }
    public required string FromPlace { get; set; }
    public required string ToPlace { get; set; }
}
