using EIV_Items.Core;
using EIV_Items.Json;
using System.Text.Json;

namespace EIV_Items.Test
{
    public class JsonTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ItemJsonInitilaizer.Initialize();
        }

        [Test]
        public void SingleItemTest()
        {

            string id = "test";

            Melee melee = new()
            {
                Id = id,
            };

            var options = JsonSerializerConvert.GetSerializerSettings();

            string json = JsonSerializer.Serialize<CoreItem>(melee, options);

            CoreItem? item = JsonSerializer.Deserialize<CoreItem>(json, options);

            Assert.That(item, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(item.Id, Is.EqualTo(id));
                Assert.That(item.ItemType, Is.EqualTo(nameof(Melee)));
            }
        }

        [Test]
        public void ItemArrayTest()
        {

            string id = "test";
            string id2 = "test2";

            Melee melee = new()
            {
                Id = id,
                ArmorDamage = 5675,
                CanUse = false,
                Damage = 76,
                DamageType = "melee13",
                Volume = 6,
                Weight = 5,
                Tags = ["test", "test2"]
            };

            Melee melee2 = new()
            {
                Id = id2,
            };

            var options = JsonSerializerConvert.GetSerializerSettings();

            string json = JsonSerializer.Serialize<List<CoreItem>>([melee, melee2], options);

            List<CoreItem>? items = JsonSerializer.Deserialize<List<CoreItem>>(json, options);

            Assert.That(items, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(items, Is.Not.Empty);
            }
        }
    }
}
