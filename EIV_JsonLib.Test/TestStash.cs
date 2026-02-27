using EIV_JsonLib.Extension;
using EIV_JsonLib.Formatter;

namespace EIV_JsonLib.Test;

public class TestStash
{
    FormatterFixture fixture;

    public TestStash(FormatterFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
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
            Assert.NotNull(stash);
            Assert.Empty(stash.Items);
            Assert.Equal(stash.MaxVolume, 35);
        });
        var ser = stash.Serialize();
        Assert.NotNull(ser);
        Assert.NotEmpty(ser);
        var stash2 = ser.Deserialize<Stash>();
        Assert.NotNull(stash2);
        Assert.Equal(stash2, stash);
        stash.Items.Add(new Ammo()
        { 
            Id = "sf",
            ItemType = nameof(Ammo),
        });
        ser = stash.Serialize();
        Assert.NotNull(ser);
        Assert.NotEmpty(ser);
        stash2 = ser.Deserialize<Stash>();
        Assert.NotNull(stash2);
        Assert.Multiple(() =>
        {
            Assert.Equal(stash2, stash);
            Assert.Equal(stash.Items.Count, 1);
        });
    }
}
