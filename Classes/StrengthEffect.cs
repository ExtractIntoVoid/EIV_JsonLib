namespace EIV_JsonLib.Classes;

public class StrengthEffect
{
    public int Min { get; set; }
    public int Max { get; set; }
    public List<string> ApplyTo { get; set; } = new();
}
