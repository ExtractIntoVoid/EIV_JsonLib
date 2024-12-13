using EIV_JsonLib.Base;

namespace EIV_JsonLib.Lobby.ItemActions;

public class MoveAction
{
    public required CoreItem Item { get; set; }
    public required string Place { get; set; }
}
