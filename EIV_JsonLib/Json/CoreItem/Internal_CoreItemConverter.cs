using System.Text.Json.Serialization;

namespace EIV_JsonLib.Json;

internal class Internal_CoreItemConverter : IJsonLibConverter
{
    public Type? GetType(string ItemType)
    {
        return ItemType switch
        {
            "Helmet" => typeof(Helmet),
            "Rig" => typeof(Rig),
            "Vest" => typeof(Vest),
            "Ammo" => typeof(Ammo),
            "ArmorPlate" => typeof(ArmorPlate),
            "GunMod" => typeof(GunMod),
            "Magazine" => typeof(Magazine),
            "Consumable" => typeof(Consumable),
            "Gun" => typeof(Gun),
            "Healing" => typeof(Healing),
            "Melee" => typeof(Melee),
            "Throwable" => typeof(Throwable),
            "Backpack" => typeof(Backpack),
            _ => null,
        };
    }

    public List<JsonConverter> GetJsonConverters()
    {
        return
        [
            new CoreItemConverter()
        ];
    }
}
