using EIV_Items;
using EIV_Items.Json;
using EIV_Profile.Json;
using EIV_Profile.ProfileModules;
using System.Text.Json;

namespace EIV_Profile.Test
{
    public class JsonTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ItemJsonInitilaizer.Initialize();
            ProfileJsonInitilaizer.Initialize();
        }

        [Test]
        public void SimpleProfileModuleJsonTest()
        {
            var h = new MinMaxValueModule<int>()
            {
                Name = "Health",
                Value = 100,
                MaxValue = 100,
                MinValue = 0,
                ModuleType = JsonSerializerConvert.NameWithGenerics(typeof(MinMaxValueModule<int>))
            };

            var options = JsonSerializerConvert.GetSerializerSettings();

            string json = JsonSerializer.Serialize<IProfileModule>(h, options);

            JsonSerializer.Deserialize<IProfileModule>(json, options);
        }

        [Test]
        public void CharacterJsonTest()
        {
            UserCharacter User = new()
            {
                Name = "Test",
                Modules = [],
                Inventory = new()
                { 
                    Hand = new Gun(),
                    ToolBelt = [ new Throwable() ],
                    Wearables = [ new Rig() ],
                },
            };

            var h = new MinMaxValueModule<int>()
            {
                Name = "Health",
                Value = 100,
                MaxValue = 100,
                MinValue = 0,
                ModuleType = JsonSerializerConvert.NameWithGenerics(typeof(MinMaxValueModule<int>))
            };

            User.Modules.Add(h);

            var options = JsonSerializerConvert.GetSerializerSettings();

            string json = JsonSerializer.Serialize(User, options);
            JsonSerializer.Deserialize<UserCharacter>(json, options);
        }
    }
}
