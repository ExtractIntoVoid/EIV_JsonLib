namespace EIV_JsonLib.Interfaces;

public partial interface IDurable
{
    /// <summary>
    /// How long the item "live" until worn off.
    /// </summary>
    public uint Durability { get; set; }
}
