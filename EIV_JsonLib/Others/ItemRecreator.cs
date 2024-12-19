using MemoryPack;

namespace EIV_JsonLib;

/// <summary>
/// Internally cannot be deserialized since this is Just a json
/// </summary>
[MemoryPackable(GenerateType.CircularReference)]
public partial class ItemRecreator
{
    [MemoryPackConstructor]
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

    [MemoryPackOrder(0)]
    public string ItemBaseID { get; set; } = string.Empty;

    [MemoryPackOrder(1)]
    public uint Amount { get; set; } = 1;

    [MemoryPackOrder(2)]
    [MemoryPackAllowSerialize]
    public List<ItemRecreator> Contained { get; set; } = [];

    [MemoryPackOrder(3)]
    public AcceptedSlots Slot { get; set; } = AcceptedSlots.None; //AcceptedSlots

    //  We set 0 always so that means not damaged any precent, only applied if it's using IDurable
    [MemoryPackOrder(4)]
    public Dictionary<string, KVChange> ChangedValues { get; set; } = [];
    public override string ToString()
    {
        return $"ItemBaseID: {ItemBaseID}, Amount: {Amount}, Slot: {Slot}, ChangedValues: {ChangedValues.Count}";
    }
}

[MemoryPackable]
public partial class KVChange
{
    public TypeName AvailableTypeName;
    public string? StringValue;
    public uint? UIntValue;
    public int? IntValue;
    public decimal? DecimalValue;
    public List<string>? ListStringValue;
    public double? DoubleValue;

    public override string ToString()
    {
        return $"AvailableTypeName: {AvailableTypeName.ToString()} String? {StringValue}, Uint? {UIntValue}, Int? {IntValue}, Dec? {DecimalValue}, ListString? {ListStringValue}";
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
    Double,
}
