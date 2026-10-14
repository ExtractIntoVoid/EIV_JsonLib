using EIV_Items.Core;
using EIV_Items.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EIV_Items.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ItemJsonInitilaizer.Initialize();
        }

        [Test]
        public void Test1()
        {

            Melee melee = new()
            {
                Id = "test",
            };

            var options = JsonSerializerConvert.GetSerializerSettings();

            string json = JsonSerializer.Serialize(melee, options);
            Console.WriteLine(json);
            CoreItem? item = JsonSerializer.Deserialize<CoreItem>(json, options);

            Assert.That(item, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(item.Id, Is.EqualTo("test"));
                Assert.That(item.ItemType, Is.EqualTo(nameof(Melee)));
            }
        }
    }
}
