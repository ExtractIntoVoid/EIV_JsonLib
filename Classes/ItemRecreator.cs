using EIV_JsonMP.Formatters;
using MessagePack;

namespace EIV_JsonLib.Classes;

/// <summary>
/// Internally cannot be deserialized since this is Just a json
/// </summary>
[MessagePackFormatter(typeof(ItemRecreatorFormatter))]
public class ItemRecreator
{
    public ItemRecreator()
    { 

    }

    public ItemRecreator(string itemId)
    {
        ItemBaseID = itemId;
    }

    public ItemRecreator(string itemId, uint amount)
    {
        ItemBaseID = itemId;
        Amount = amount;
    }

    public ItemRecreator(string itemId, uint amount, List<ItemRecreator> itemRecreators)
    {
        ItemBaseID = itemId;
        Amount = amount;
        Contained = itemRecreators;
    }

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
        public List<string>? ListStringValue;

        public override string ToString()
        {
            return $"AvailableTypeName: {AvailableTypeName.ToString()} String? {StringValue}, Uint? {UIntValue}, Int? {IntValue}, Dec? {DecimalValue}, ListString? {ListStringValue}";
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

public enum TypeName : byte
{
    String,
    Int,
    UInt,
    Decimal,
    List_String,
}
