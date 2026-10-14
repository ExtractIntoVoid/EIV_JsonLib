namespace EIV_Items.Interfaces;

public partial interface IDurable
{
    /// <summary>
    /// How long the item "live" until worn off.
    /// </summary>
    public uint Durability { get; set; }
}
