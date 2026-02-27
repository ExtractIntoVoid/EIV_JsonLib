using EIV_JsonLib.Base;
using EIV_JsonLib.Extension;
using EIV_JsonLib.Formatter;

namespace EIV_JsonLib.Test;

public class TestItems
{

    FormatterFixture fixture;

    public TestItems(FormatterFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
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
            Assert.Equal(gun2, gun);
            Assert.Equal(gun3, gun);
        });
    }

    [Fact]
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
        Assert.NotNull(gun.Magazine);
        Assert.Empty(gun.Magazine!.Ammunitions);
        var ser = gun.Serialize();
        Assert.NotNull(ser);
        Assert.NotEmpty(ser);
        var NewGun = ser.Deserialize<Gun>();
        Assert.NotNull(NewGun);
        Assert.Equal(NewGun, gun);
        NewGun!.Magazine!.Ammunitions.Add(new Ammo()
        { 
            Id = "Ammo1",
            ItemType = nameof(Ammo),
            Damage = 777
        });
        Assert.NotEqual(NewGun, gun);
    }
   
}
