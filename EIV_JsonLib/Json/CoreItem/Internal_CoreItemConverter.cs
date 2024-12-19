using System.Text.Json.Serialization;

namespace EIV_JsonLib.Json;

internal class Internal_CoreItemConverter : IJsonLibConverter
{
    public Type? GetType(string ItemType)
    {
        return ItemType switch
        {
            "Backpack" => typeof(Backpack),
            "Ammo" => typeof(Ammo),
            "Magazine" => typeof(Magazine),
            "GunMod" => typeof(GunMod),
            "ArmorPlate" => typeof(ArmorPlate),
            "Rig" => typeof(Rig),
            "Consumable" => typeof(Consumable),
            "Throwable" => typeof(Throwable),
            "Melee" => typeof(Melee),
            "Gun" => typeof(Gun),
            "Healing" => typeof(Healing),
            "Helmet" => typeof(Helmet),
            "Vest" => typeof(Vest),
            _ => null,
        };
    }

    public List<JsonConverter> GetJsonConverters()
    {
        return
        [
            new CoreItemConverter()
            // Add ArmorBase, UsableBase here
        ];
    }
}
