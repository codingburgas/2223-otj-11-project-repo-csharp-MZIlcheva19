using Microsoft.EntityFrameworkCore;
using bsm.dal.Data;
using System.Text.Json;

namespace wm.tests
{
    public class Utilities
    {
        public static BeautySalonContext Generate()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BeautySalonContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging();

            return new BeautySalonContext(optionsBuilder.Options);
        }

        public static void AreEqualByJson(object expected, object actual)
        {
            var expectedJson = JsonSerializer.Serialize(expected);
            var actualJson = JsonSerializer.Serialize(actual);

            Assert.That(expectedJson, Is.EqualTo(actualJson));
        }
    }
}