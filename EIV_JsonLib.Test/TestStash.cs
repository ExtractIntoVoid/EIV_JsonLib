using EIV_JsonLib.Extension;
using EIV_JsonLib.Formatter;

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
        Stash stash = new()
        { 
            Items = [],
            MaxVolume = 35,
            MaxSize = 53,
            MaxWeight = 543
        };
        Assert.Multiple(() =>
        {
            Assert.That(stash, Is.Not.Null);
            Assert.That(stash.Items, Is.Empty);
            Assert.That(stash.MaxVolume, Is.EqualTo(35));
        });
        var ser = stash.Serialize();
        Assert.That(ser, Is.Not.Null);
        Assert.That(ser, Is.Not.Empty);
        var stash2 = ser.Deserialize<Stash>();
        Assert.That(stash2, Is.Not.Null);
        Assert.That(stash2, Is.EqualTo(stash));
        stash.Items.Add(new Ammo()
        { 
            Id = "sf",
            ItemType = nameof(Ammo),
        });
        ser = stash.Serialize();
        Assert.That(ser, Is.Not.Null);
        Assert.That(ser, Is.Not.Empty);
        stash2 = ser.Deserialize<Stash>();
        Assert.That(stash2, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(stash2, Is.EqualTo(stash));
            Assert.That(stash.Items, Has.Count.EqualTo(1));
        });
    }
}
