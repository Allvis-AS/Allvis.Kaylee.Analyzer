using Allvis.Kaylee.Analyzer.Models;
using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using Xunit;
using Xunit.Categories;

namespace Allvis.Kaylee.Analyzer.Tests.Unit.Models
{
    [UnitTest]
    public class UniqueKeyTest
    {
        [Fact]
        public void TestThatUniqueKeyAddsItselfToEntity()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var role = schema.Locate(new[] { "Role" });
            // Act
            var uniqueKey = new UniqueKey(role);
            // Assert
            Assert.Equal(new[] { uniqueKey }, role.UniqueKeys);
        }
    }
}
