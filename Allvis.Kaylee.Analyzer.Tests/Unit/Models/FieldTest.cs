using Allvis.Kaylee.Analyzer.Models;
using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using Xunit;
using Xunit.Categories;

namespace Allvis.Kaylee.Analyzer.Tests.Unit.Models
{
    [UnitTest]
    public class FieldTest
    {
        [Fact]
        public void TestThatFieldAddsItselfToEntity()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var role = schema.Locate(new[] { "Role" });
            // Act
            var roleId = new Field(role)
            {
                Name = "RoleId"
            };
            // Assert
            Assert.Equal(new[] { roleId }, role.Fields);
        }
    }
}
