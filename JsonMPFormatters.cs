using EIV_JsonLib.Classes;
using EIV_JsonLib.Interfaces;
using EIV_JsonMP.Formatters;
using MessagePack.Formatters;

namespace EIV_JsonMP;

public static class JsonMPFormatters
{
    public static Dictionary<Type, IMessagePackFormatter> Formatters = new()
    {
        { typeof(IAmmo), new AmmoFormatter() },
        { typeof(IArmoredRig), new ArmoredRigFormatter() },
        { typeof(IArmor), new ArmorFormatter() },
        { typeof(IArmorPlate), new ArmorPlateFormatter() },
        { typeof(IAttachment), new AttachmentFormatter() },
        { typeof(IBackpack), new BackpackFormatter() },
        { typeof(IGun), new GunFormatter() },
        { typeof(IHealing), new HealingFormatter() },
        { typeof(IItem), new ItemFormatter() },
        { typeof(ItemRecreator), new ItemRecreatorFormatter() },
        { typeof(IMagazine), new MagazineFormatter() },
        { typeof(IMelee), new MeleeFormatter() },
        { typeof(IRig), new RigFormatter() },
        { typeof(IStash), new StashFormatter() },
        { typeof(IThrowable), new ThrowableFormatter() },
        { typeof(IEffect), new EffectFormatter() },
        { typeof(IConsumable), new ConsumableFormatter() },
        // add more your own custom serializers.
    };

    public static IMessagePackFormatter? GetFormatter(Type t)
    {
        IMessagePackFormatter? formatter;
        if (Formatters.TryGetValue(t, out formatter))
        {
            return formatter;
        }

        // If type can not get, must return null for fallback mechanism.
        return null;
    }
}
