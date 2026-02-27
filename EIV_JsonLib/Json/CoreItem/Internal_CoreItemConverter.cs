#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json;
#endif

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
