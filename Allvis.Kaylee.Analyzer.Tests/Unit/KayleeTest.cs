using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using Xunit;
using Xunit.Categories;

namespace Allvis.Kaylee.Analyzer.Tests.Unit
{
    [UnitTest]
    public class KayleeTest
    {
        [Fact]
        public void TestParse()
        {
            // Arrange
            var tModel = ModelFixture.Create();
            // Act
            var ast = Kaylee.Parse(tModel);
            // Assert
            Assert.Collection(ast.Schemata,
                s => Assert.Equal("auth", s.Name),
                s => Assert.Equal("tenant", s.Name));
        }
    }
}
