using Allvis.Kaylee.Analyzer.Exceptions;
using Allvis.Kaylee.Analyzer.Models;
using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using System.Linq;
using Xunit;

namespace Allvis.Kaylee.Analyzer.Tests.Unit.Models
{
    public class SchemaTest
    {
        [Fact]
        public void TestThatSchemaAddsItselfToAst()
        {
            // Arrange
            var ast = new Ast();
            // Act
            var core = new Schema(ast)
            {
                Name = "core"
            };
            var auth = new Schema(ast)
            {
                Name = "auth"
            };
            // Assert
            Assert.Equal(new[] { core, auth }, ast.Schemata);
        }

        [Fact]
        public void TestLocate()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var role = schema.Entities.Single(e => e.Name == "Role");
            var path = new[] { "Role", "Info" };
            // Act
            var roleInfo = schema.Locate(path);
            // Assert
            Assert.Equal(role, roleInfo.Parent);
        }

        [Fact]
        public void TestLocate_ThrowsForNonExistentEntities()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            // Act & Assert
            Assert.Throws<EntityNotFoundException>(() => schema.Locate(new[] { "User", "VoidEntity" }));
        }
    }
}
