using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using System.Linq;
using Xunit;
using Xunit.Categories;

namespace Allvis.Kaylee.Analyzer.Tests.Unit.Models
{
    [UnitTest]
    public class AstTest
    {
        [Fact]
        public void TestLocate()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var role = schema.Entities.Single(e => e.Name == "Role");
            var path = new[] { "Role", "Info" };
            // Act
            var roleInfo = schema.Ast.Locate("core", path);
            // Assert
            Assert.Equal(role, roleInfo.Parent);
        }
    }
}
