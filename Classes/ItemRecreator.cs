using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Classes;

/// <summary>
/// Internally cannot be deserialized since this is Just a json
/// </summary>
[MessagePackFormatter(typeof(ItemRecreatorFormatter))]
public class ItemRecreator
{
    public string ItemBaseID { get; set; } = string.Empty;
    public uint Amount { get; set; } = 1;
    public List<ItemRecreator> Contained { get; set; } = [];
    public AcceptedSlots Slot { get; set; } = AcceptedSlots.None; //AcceptedSlots

    //  We set 0 always so that means not damaged any precent, only applied if it's using IDurable
    public Dictionary<string, KVChange> ChangedValues { get; set; } = [];
    public override string ToString()
    {
        return $"ItemBaseID: {ItemBaseID}, Amount: {Amount}, Slot: {Slot}, ChangedValues: {ChangedValues.Count}";
    }

    public class KVChange
    {
        public TypeName AvailableTypeName;
        public string? StringValue;
        public uint? UIntValue;
        public int? IntValue;
        public decimal? DecimalValue;

        public override string ToString()
        {
            return $"AvailableTypeName: {AvailableTypeName.ToString()} String? {StringValue}, Uint? {UIntValue}, Int? {IntValue}, Dec? {DecimalValue}";
        }
    }
}

public enum AcceptedSlots : byte
{
    None = 0,
    ItemsSlot,
    AmmoSlot,
    MagazineSlot,
    PlateSlot,
}

[Flags]
public enum TypeName : byte
{
    String = 1,
    Int32 = 2,
    UInt32 = 4,
    Decimal = 8,
}
