using Allvis.Kaylee.Analyzer.Models;
using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using Xunit;
using Xunit.Categories;

namespace Allvis.Kaylee.Analyzer.Tests.Unit.Models
{
    [UnitTest]
    public class MutationTest
    {
        [Fact]
        public void TestThatMutationAddsItselfToEntity()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var user = schema.Locate(new[] { "User" });
            // Act
            var contactInformation = new Mutation(user)
            {
                Name = "ContactInformation"
            };
            // Assert
            Assert.Equal(new[] { contactInformation }, user.Mutations);
        }
    }
}
