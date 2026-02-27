using EIV_JsonLib.Extension;
using EIV_JsonLib.Formatter;
using EIV_JsonLib.Json;
using EIV_JsonLib.Profile;
using EIV_JsonLib.Profile.ProfileModules;
using System.Diagnostics;

namespace EIV_JsonLib.Test;

public class TestProfile
{

    FormatterFixture fixture;

    public TestProfile(FormatterFixture fixture)
    {
        this.fixture = fixture;
    }
    [Fact]
    public void TestUserCreation()
    {
        UserCharacter User = new()
        {
            Name = "Test",
            Modules = [],
            Inventory = new(),
        };
        Assert.Multiple(() =>
        {
            Assert.Equal(User.Name, "Test");
            Assert.Equal(User.Origin,string.Empty);
            Assert.Equal(User.CreationDate, DateTimeOffset.MinValue);
            Assert.Empty(User.Modules);
            Assert.Null(User.Inventory.Hand);
            Assert.Empty(User.Inventory.Wearables);
            Assert.Empty(User.Inventory.ToolBelt);
        });
    }

    [Fact]
    public void TestModules()
    {
        UserCharacter? User = new()
        {
            Name = "Test",
            Modules = [],
            Inventory = new(),
        };
        User.Modules.Add(new MinMaxValueModule<int>()
        {
            Name = "Health",
            Value = 100,
            MaxValue = 100,
            MinValue = 0,
            ModuleType = nameof(MinMaxValueModule<int>)
        });
        User.Modules.Add(new MinMaxValueModule<int>()
        {
            Name = "Health",
            Value = 300,
            MaxValue = 100,
            MinValue = 0,
            ModuleType = nameof(MinMaxValueModule<int>)
        });
        User.Modules.Add(new ValueModule<int>()
        {
            Name = "Level",
            Value = 300,
            ModuleType = nameof(ValueModule<int>)
        });
        User.Modules.Add(new ReadOnlyValueModule<int>()
        {
            Name = "RO_Level",
            Value = 300,
            ModuleType = nameof(ReadOnlyValueModule<int>)
        });
        User.Modules.Add(new StatusEffectModule()
        {
            Name = "StatusEffects",
            Effects =
            {
                new SideEffect()
                {
                    EffectName = "Test",
                    EffectStrength = 4,
                    EffectTime = 55,
                }
            }
        });
        Assert.Equal(User.Modules.Count, 5);
        StatusEffectModule? statusEffectModule = User.GetProfileModule<StatusEffectModule>("StatusEffects");
        Assert.NotNull(statusEffectModule);
        Assert.Multiple(() =>
        {
            Assert.Equal(statusEffectModule!.Effects.Count, 1);
            Assert.Null(User.GetProfileModule<StatusEffectModule>("Null"));
        });
        MinMaxValueModule<int>? Health = User.GetProfileModule<MinMaxValueModule<int>>("Health");
        Assert.NotNull(Health);
        Assert.Equal(Health!.Value, 100);
        Health.Value = 200;
        Assert.Equal(Health!.Value, 200);
        Health = User.GetProfileModule<MinMaxValueModule<int>>("Health");
        Assert.NotNull(Health);
        Assert.Multiple(() =>
        {
            Assert.Equal(Health!.Value, 200);
            Assert.False(User.IsProfileModuleNameExist("MustNotExists"));
            Assert.True(User.IsProfileModuleNameExist("Health"));
        });
    }

    [Fact]
    public void TestDeSer()
    {
        UserCharacter User = new()
        {
            Name = "Test",
            Modules = [],
            Inventory = new(),
        };
        var SerUser = User.Serialize();
        Assert.NotNull(SerUser);
        var DeserUser = SerUser.Deserialize<UserCharacter>();
        Assert.NotNull(DeserUser);
        Assert.Equal(DeserUser, User);
        User.Modules.Add(new MinMaxValueModule<int>()
        {
            Name = "Health",
            Value = 100,
            MaxValue = 100,
            MinValue = 0,
            ModuleType = nameof(MinMaxValueModule<int>)
        });
        SerUser = User.Serialize();
        Assert.NotNull(SerUser);
        DeserUser = SerUser.Deserialize<UserCharacter>();
        Assert.NotNull(DeserUser);
        Assert.Equal(DeserUser, User);
        User.CreationDate = DateTimeOffset.Now;
        SerUser = User.Serialize();
        Assert.NotNull(SerUser);
        DeserUser = SerUser.Deserialize<UserCharacter>();
        Assert.NotNull(DeserUser);
        Assert.Equal(DeserUser, User);
        User.Inventory.Hand = new Gun()
        {
            Id = "Gun",
            ItemType = nameof(Gun),
        };
        SerUser = User.Serialize();
        Assert.NotNull(SerUser);
        DeserUser = SerUser.Deserialize<UserCharacter>();
        Assert.NotNull(DeserUser);
        Assert.Equal(DeserUser, User);
    }


    [Fact]
    public void TestJsonConverting()
    {
        /*
        UserCharacter User = new()
        {
            Name = "Test",
            Modules = [],
            Inventory = new(),
        };
        var json = JsonSerializer.Serialize(User, ConvertHelper.GetSerializerSettings());
        Assert.NotNull(json);
        Assert.That(json, Is.Not.Empty);
        var userCharacter = JsonSerializer.Deserialize<UserCharacter>(json, ConvertHelper.GetSerializerSettings());
        Assert.NotNull(userCharacter);
        Assert.Multiple(() =>
        {
            Assert.That(userCharacter!.Name, Is.EqualTo(User.Name));
            Assert.That(userCharacter!.Modules, Is.EqualTo(User.Modules));
            Assert.That(userCharacter!.Inventory, Is.EqualTo(User.Inventory));
            Assert.That(userCharacter, Is.EqualTo(User));
        });
        Assert.That(userCharacter, Is.EqualTo(User));

        User.Modules.Add(new MinMaxValueModule<int>()
        {
            Name = "Health",
            Value = 100,
            MaxValue = 100,
            MinValue = 0,
            ModuleType = nameof(MinMaxValueModule<int>)
        });
        json = JsonSerializer.Serialize(User, ConvertHelper.GetSerializerSettings());
        Assert.NotNull(json);
        Assert.That(json, Is.Not.Empty);
        userCharacter = JsonSerializer.Deserialize<UserCharacter>(json, ConvertHelper.GetSerializerSettings());
        Assert.NotNull(userCharacter);
        Assert.That(userCharacter, Is.EqualTo(User));

        User.Inventory.Hand = new Gun()
        {
            Id = "Gun",
            ItemType = nameof(Gun),
        };
        json = JsonSerializer.Serialize(User, ConvertHelper.GetSerializerSettings());
        Assert.NotNull(json);
        Assert.That(json, Is.Not.Empty);
        userCharacter = JsonSerializer.Deserialize<UserCharacter>(json, ConvertHelper.GetSerializerSettings());
        Assert.NotNull(userCharacter);
        Assert.That(userCharacter, Is.EqualTo(User));
        */
    }
}