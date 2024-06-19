namespace EIV_JsonLib.Interfaces;

// DONT FORMAT THIS, Only used in other Formatter!
public interface IDurable : IItem
{
    public uint Durability { get; set; }
}
