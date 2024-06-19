using EIV_JsonLib.Convert;
using Newtonsoft.Json;

namespace EIV_JsonLib.Modding;

internal class Internal_JsonLibConverter : IJsonLibConverter
{
    public JsonConverter? GetJsonConverter(string ItemType)
    {
        return ItemType switch
        {
            "IAmmo" => new AmmoConverter(),
            "IArmor" => new ArmorConverter(),
            "IArmoredRig" => new ArmoredRigConverter(),
            "IArmorPlate" => new ArmorPlateConverter(),
            "IAttachment" => new AttachmentConvert(),
            "IBackpack" => new BackpackConverter(),
            "IGun" => new GunConverter(),
            "IHealing" => new HealingConverter(),
            "IMagazine" => new MagazineConverter(),
            "IMelee" => new MeleeConverter(),
            "IRig" => new RigConverter(),
            "IStash" => new StashConverter(),
            "IThrowable" => new ThrowableConverter(),
            _ => null,
        };
    }

    public List<JsonConverter> GetJsonConverters()
    {
        return
        [
            new AmmoConverter(),
            new ArmorConverter(),
            new ArmoredRigConverter(),
            new ArmorPlateConverter(),
            new AttachmentConvert(),
            new BackpackConverter(),
            new GunConverter(),
            new HealingConverter(),
            new MagazineConverter(),
            new MeleeConverter(),
            new RigConverter(),
            new StashConverter(),
            new ThrowableConverter(),
        ];
    }
}
