using EIV_Pack;

namespace EIV_JsonLib;

/// <summary>
/// Internally cannot be deserialized since this is Just a json
/// </summary>
[EIV_Packable]
public partial class ItemRecreator
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

    public override int GetHashCode()
    {
        int hash = 0;
        if (!string.IsNullOrEmpty(ItemBaseID))
            hash += ItemBaseID.GetHashCode();
        hash += Amount.GetHashCode();
        if (Contained.Count != 0)
            hash += (int)Contained.Select(x => x.GetHashCode()).Average();
        hash += Slot.GetHashCode();
        if (ChangedValues.Count != 0)
            hash += (int)ChangedValues.Select(x => x.Key.GetHashCode() + x.Value.GetHashCode()).Average();
        return hash;
    }
}

[EIV_Packable]
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
        return $"AvailableTypeName: {AvailableTypeName} String? {StringValue}, Uint? {UIntValue}, Int? {IntValue}, Dec? {DecimalValue}, ListString? {ListStringValue}";
    }

    public override int GetHashCode()
    {
        int hash = AvailableTypeName.GetHashCode();
        if (ListStringValue != null && ListStringValue.Count != 0)
            hash += (int)ListStringValue.Select(x => x.GetHashCode()).Average();
        if (!string.IsNullOrEmpty(StringValue))
            hash += StringValue!.GetHashCode();
        if (UIntValue != null)
            hash += UIntValue.GetHashCode();
        if (IntValue != null)
            hash += IntValue.GetHashCode();
        if (DecimalValue != null)
            hash += DecimalValue.GetHashCode();
        if (DoubleValue != null)
            hash += DoubleValue.GetHashCode();
        return hash;
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
