namespace EIV_Items.Interfaces;

/// <summary>
/// Makes the item have durability.
/// </summary>
/// <remarks>
/// This can make item destroyed.
/// </remarks>
public partial interface IDurable
{
    /// <summary>
    /// Gets how long the item "live" until worn off.
    /// </summary>
    public uint Durability { get; }
}
