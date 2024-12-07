namespace EIV_JsonLib.Interface;

/// <summary>
/// Wearable interface, let the player Wear this item.
/// </summary>
public interface IWearable
{
    /// <summary>
    /// Slot where is the Item can be put.
    /// </summary>
    public string Slot { get; set; }
}
