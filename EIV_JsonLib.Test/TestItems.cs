using EIV_JsonLib.Base;
using EIV_JsonLib.Extension;
using System.Text.Json;

namespace EIV_JsonLib.Test;

public class TestItems
{
    [SetUp]
    public void Setup()
    {
        FormatterInitializer.RegisterFormatter();
    }

    [Test]
    public void TestItemParsing()
    {
        CoreItem gun = new Gun()
        { 
            Id = "Gun",
            ItemType = nameof(Gun),
            AmmoSupported = ["sdfsf"],
            Volume = 66
        };
        CoreUsable gun2 = new Gun()
        {
            Id = "Gun",
            ItemType = nameof(Gun),
            AmmoSupported = ["sdfsf"],
            Volume = 66
        };
        Gun gun3 = new Gun()
        {
            Id = "Gun",
            ItemType = nameof(Gun),
            AmmoSupported = ["sdfsf"],
            Volume = 66
        };
        Assert.That(gun2, Is.EqualTo(gun));
        Assert.That(gun3, Is.EqualTo(gun));
    }

    [Test]
    public void TestItemContainsOtherItem()
    {
        Gun gun = new Gun()
        {
            Id = "Gun",
            ItemType = nameof(Gun),
            AmmoSupported = ["sdfsf"],
            Volume = 66,
            Magazine = new()
            {
                Id = "TestMag",
                ItemType = nameof(Magazine),
                Ammunitions = new(),
                Weight = 7456.99M
            }
        };
        Assert.IsNotNull(gun.Magazine);
        Assert.That(gun.Magazine!.Ammunitions.Count, Is.EqualTo(0));
        var ser = gun.Serialize();
        Assert.IsNotNull(ser);
        Assert.IsNotEmpty(ser);
        var NewGun = ser.Deserialize<Gun>();
        Assert.IsNotNull(NewGun);
        Assert.That(NewGun, Is.EqualTo(gun));
        NewGun!.Magazine!.Ammunitions.Add(new Ammo()
        { 
            Id = "Ammo1",
            ItemType = nameof(Ammo),
            Damage = 777
        });
        Assert.That(NewGun, Is.Not.EqualTo(gun));
    }
   
}
