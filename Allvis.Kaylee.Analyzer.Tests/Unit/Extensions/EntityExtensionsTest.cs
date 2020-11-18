using Allvis.Kaylee.Analyzer.Extensions;
using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using System;
using System.Linq;
using Xunit;
using Xunit.Categories;

namespace Allvis.Kaylee.Analyzer.Tests.Unit.Extensions
{
    [UnitTest]
    public class EntityExtensionsTest
    {
        [Theory]
        [InlineData(true, new[] { "User" }, new[] { "User", "Role" })]
        [InlineData(true, new[] { "User" }, new[] { "User", "Role", "Info" })]
        [InlineData(false, new[] { "User", "Role" }, new[] { "User" })]
        [InlineData(false, new[] { "Role" }, new[] { "User", "Role" })]
        [InlineData(false, new[] { "Role" }, new[] { "User", "Role", "Info" })]
        public void TestIsAncestorOf(bool expected, string[] ancestorPath, string[] childPath)
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var ancestor = schema.Locate(ancestorPath);
            var child = schema.Locate(childPath);
            // Act
            var isAncestor = ancestor.IsAncestorOf(child);
            // Assert
            Assert.Equal(expected, isAncestor);
        }

        [Fact]
        public void TestIsAncestorOf_ThrowsForEqualAncestorAndChild()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var user = schema.Locate(new[] { "User" });
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => user.IsAncestorOf(user));
        }

        [Fact]
        public void TestGetFullPrimaryKey()
        {
            // Arrange
            var tModel = ModelFixture.Create();
            var ast = KayleeHelper.Parse(tModel);
            var procedure = ast.Locate("tenant", new[] { "Tenant", "Procedure" });
            // Act
            var fullPrimaryKey = procedure.GetFullPrimaryKey();
            // Assert
            var expected = new[] {
                procedure.Parent.PrimaryKey.Single(),
                procedure.PrimaryKey.Single()
            };
            Assert.Equal(expected, fullPrimaryKey);
        }
    }
}
