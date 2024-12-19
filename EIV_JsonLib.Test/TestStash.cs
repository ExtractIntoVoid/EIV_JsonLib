using EIV_JsonLib.Extension;

namespace EIV_JsonLib.Test;

public class TestStash
{
    [SetUp]
    public void Setup()
    {
        FormatterInitializer.RegisterFormatter();
    }

    [Test]
    public void TestStashCreateAndParse()
    {
        Stash stash = new Stash()
        { 
            Items = [],
            MaxVolume = 35,
            MaxSize = 53,
            MaxWeight = 543
        };
        Assert.IsNotNull(stash);
        Assert.IsEmpty(stash.Items);
        Assert.That(stash.MaxVolume, Is.EqualTo(35));
        var ser = stash.Serialize();
        Assert.IsNotNull(ser);
        Assert.IsNotEmpty(ser);
        var stash2 = ser.Deserialize<Stash>();
        Assert.IsNotNull(stash2);
        Assert.That(stash2, Is.EqualTo(stash));
        stash.Items.Add(new Ammo()
        { 
            Id = "sf",
            ItemType = nameof(Ammo),
        });
        ser = stash.Serialize();
        Assert.IsNotNull(ser);
        Assert.IsNotEmpty(ser);
        stash2 = ser.Deserialize<Stash>();
        Assert.IsNotNull(stash2);
        Assert.That(stash2, Is.EqualTo(stash));
        Assert.That(stash.Items.Count, Is.EqualTo(1));
    }
}
