using EIV_JsonLib.Profile.ProfileModules;
using EIV_JsonLib.Profile;
using EIV_JsonLib.Extension;
using System.Text.Json;
using EIV_JsonLib.Json;
using EIV_JsonLib.Formatter;

namespace EIV_JsonLib.Test;

public class TestProfile
{
    [SetUp]
    public void Setup()
    {
        FormatterInitializer.RegisterFormatter();
    }

    [Test]
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
            Assert.That(User.Name, Is.EqualTo("Test"));
            Assert.That(User.Origin, Is.EqualTo(string.Empty));
            Assert.That(User.CreationDate, Is.EqualTo(DateTimeOffset.MinValue));
            Assert.That(User.Modules, Is.Empty);
            Assert.That(User.Inventory.Hand, Is.EqualTo(null));
            Assert.That(User.Inventory.Wearables, Is.Empty);
            Assert.That(User.Inventory.ToolBelt, Is.Empty);
        });
    }

    [Test]
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
        Assert.That(User.Modules, Has.Count.EqualTo(5));
        StatusEffectModule? statusEffectModule = User.GetProfileModule<StatusEffectModule>("StatusEffects");
        Assert.That(statusEffectModule, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(statusEffectModule!.Effects, Has.Count.EqualTo(1));
            Assert.That(User.GetProfileModule<StatusEffectModule>("Null"), Is.Null);
        });
        MinMaxValueModule<int>? Health = User.GetProfileModule<MinMaxValueModule<int>>("Health");
        Assert.That(Health, Is.Not.Null);
        Assert.That(Health!.Value, Is.EqualTo(100));
        Health.Value = 200;
        Assert.That(Health!.Value, Is.EqualTo(200));
        Health = User.GetProfileModule<MinMaxValueModule<int>>("Health");
        Assert.That(Health, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(Health!.Value, Is.EqualTo(200));
            Assert.That(User.IsProfileModuleNameExist("MustNotExists"), Is.EqualTo(false));
            Assert.That(User.IsProfileModuleNameExist("Health"), Is.EqualTo(true));
        });
    }

    [Test]
    public void TestDeSer()
    {
        UserCharacter User = new()
        {
            Name = "Test",
            Modules = [],
            Inventory = new(),
        };
        var SerUser = User.Serialize();
        Assert.That(SerUser, Is.Not.Null);
        var DeserUser = SerUser.Deserialize<UserCharacter>();
        Assert.That(DeserUser, Is.Not.Null);
        Assert.That(DeserUser, Is.EqualTo(User));
        User.Modules.Add(new MinMaxValueModule<int>()
        {
            Name = "Health",
            Value = 100,
            MaxValue = 100,
            MinValue = 0,
            ModuleType = nameof(MinMaxValueModule<int>)
        });
        SerUser = User.Serialize();
        Assert.That(SerUser, Is.Not.Null);
        DeserUser = SerUser.Deserialize<UserCharacter>();
        Assert.That(DeserUser, Is.Not.Null);
        Assert.That(DeserUser, Is.EqualTo(User));
        User.CreationDate = DateTimeOffset.Now;
        SerUser = User.Serialize();
        Assert.That(SerUser, Is.Not.Null);
        DeserUser = SerUser.Deserialize<UserCharacter>();
        Assert.That(DeserUser, Is.Not.Null);
        Assert.That(DeserUser, Is.EqualTo(User));
        User.Inventory.Hand = new Gun()
        {
            Id = "Gun",
            ItemType = nameof(Gun),
        };
        SerUser = User.Serialize();
        Assert.That(SerUser, Is.Not.Null);
        DeserUser = SerUser.Deserialize<UserCharacter>();
        Assert.That(DeserUser, Is.Not.Null);
        Assert.That(DeserUser, Is.EqualTo(User));
    }


    [Test]
    public void TestJsonConverting()
    {
        UserCharacter User = new()
        {
            Name = "Test",
            Modules = [],
            Inventory = new(),
        };
        var json = JsonSerializer.Serialize(User, ConvertHelper.GetSerializerSettings());
        Assert.That(json, Is.Not.Null);
        Assert.That(json, Is.Not.Empty);
        var userCharacter = JsonSerializer.Deserialize<UserCharacter>(json, ConvertHelper.GetSerializerSettings());
        Assert.That(userCharacter, Is.Not.Null);
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
        Assert.That(json, Is.Not.Null);
        Assert.That(json, Is.Not.Empty);
        userCharacter = JsonSerializer.Deserialize<UserCharacter>(json, ConvertHelper.GetSerializerSettings());
        Assert.That(userCharacter, Is.Not.Null);
        Assert.That(userCharacter, Is.EqualTo(User));

        User.Inventory.Hand = new Gun()
        {
            Id = "Gun",
            ItemType = nameof(Gun),
        };
        json = JsonSerializer.Serialize(User, ConvertHelper.GetSerializerSettings());
        Assert.That(json, Is.Not.Null);
        Assert.That(json, Is.Not.Empty);
        userCharacter = JsonSerializer.Deserialize<UserCharacter>(json, ConvertHelper.GetSerializerSettings());
        Assert.That(userCharacter, Is.Not.Null);
        Assert.That(userCharacter, Is.EqualTo(User));
    }
}