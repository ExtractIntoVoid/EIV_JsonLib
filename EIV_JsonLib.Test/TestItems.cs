using EIV_JsonLib.Base;
using EIV_JsonLib.Extension;
using EIV_JsonLib.Formatter;
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
        Gun gun3 = new()
        {
            Id = "Gun",
            ItemType = nameof(Gun),
            AmmoSupported = ["sdfsf"],
            Volume = 66
        };
        Assert.Multiple(() =>
        {
            Assert.That(gun2, Is.EqualTo(gun));
            Assert.That(gun3, Is.EqualTo(gun));
        });
    }

    [Test]
    public void TestItemContainsOtherItem()
    {
        Gun gun = new()
        {
            Id = "Gun",
            ItemType = nameof(Gun),
            AmmoSupported = ["sdfsf"],
            Volume = 66,
            Magazine = new()
            {
                Id = "TestMag",
                ItemType = nameof(Magazine),
                Ammunitions = [],
                Weight = 7456.99M
            }
        };
        Assert.That(gun.Magazine, Is.Not.Null);
        Assert.That(gun.Magazine!.Ammunitions, Is.Empty);
        var ser = gun.Serialize();
        Assert.That(ser, Is.Not.Null);
        Assert.That(ser, Is.Not.Empty);
        var NewGun = ser.Deserialize<Gun>();
        Assert.That(NewGun, Is.Not.Null);
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
