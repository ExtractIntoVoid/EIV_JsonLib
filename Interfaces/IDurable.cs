namespace EIV_JsonLib.Interface;

public interface IDurable
{
    /// <summary>
    /// How long the item "live" until wown off.
    /// </summary>
    public uint Durability { get; set; }
}
