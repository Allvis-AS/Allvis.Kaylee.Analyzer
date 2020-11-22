using Allvis.Kaylee.Analyzer.Exceptions;
using Allvis.Kaylee.Analyzer.Models;
using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using System.Linq;
using Xunit;
using Xunit.Categories;

namespace Allvis.Kaylee.Analyzer.Tests.Unit.Models
{
    [UnitTest]
    public class EntityTest
    {
        [Fact]
        public void TestThatRootEntityAddsItselfToSchema()
        {
            // Arrange
            var ast = new Ast();
            var schema = new Schema(ast)
            {
                Name = "core"
            };
            // Act
            var user = new Entity(schema, null, "User", false);
            var role = new Entity(schema, null, "Role", false);
            _ = new Entity(schema, user, "Role", false);
            // Assert
            Assert.Equal(new[] { user, role }, schema.Entities);
        }
        [Fact]
        public void TestThatEntityAddsItselfToParent()
        {
            // Arrange
            var ast = new Ast();
            var schema = new Schema(ast)
            {
                Name = "core"
            };
            // Act
            var user = new Entity(schema, null, "User", false);
            var userRole = new Entity(schema, user, "Role", false);
            var userInfo = new Entity(schema, user, "Info", false);
            // Assert
            Assert.Equal(new[] { userRole, userInfo }, user.Children);
        }

        [Fact]
        public void TestPath()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var userRole = schema.Locate(new[] { "User", "Role" });
            // Act
            var path = userRole.Path;
            // Assert
            Assert.Equal(new[] { "User", "Role" }, path);
        }

        [Fact]
        public void TestLocate()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var user = schema.Entities.Single(e => e.Name == "User");
            var path = new[] { "Role", "Info" };
            // Act
            var userRoleInfo = user.Locate(path);
            // Assert
            Assert.Equal(user, userRoleInfo.Parent.Parent);
        }

        [Fact]
        public void TestLocate_ThrowsForNonExistentEntities()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var user = schema.Locate(new[] { "User" });
            // Act & Assert
            Assert.Throws<EntityNotFoundException>(() => user.Locate(new[] { "VoidEntity" }));
        }

        [Fact]
        public void TestLocate_Field()
        {
            // Arrange
            var tModel = ModelFixture.Create();
            var ast = KayleeHelper.Parse(tModel);
            var user = ast.Locate("auth", new[] { "User" });
            var fieldName = "UserId";
            var userId = user.Fields.Single(f => f.Name == fieldName);
            // Act
            var field = user.Locate(fieldName);
            // Assert
            Assert.Equal(userId, field);
        }

        [Fact]
        public void TestLocate_Field_PartOfParentKey()
        {
            // Arrange
            var tModel = ModelFixture.Create();
            var ast = KayleeHelper.Parse(tModel);
            var tenantProcedure = ast.Locate("tenant", new[] { "Tenant", "Procedure" });
            var fieldName = "TenantId";
            var tenantId = tenantProcedure.Parent.Fields.Single(f => f.Name == fieldName);
            // Act
            var field = tenantProcedure.Locate(fieldName);
            // Assert
            Assert.Equal(tenantId, field);
        }

        [Fact]
        public void TestLocate_Field_ThrowsForNonExistentFields()
        {
            // Arrange
            var tModel = ModelFixture.Create();
            var ast = KayleeHelper.Parse(tModel);
            var user = ast.Locate("auth", new[] { "User" });
            // Act & Assert
            Assert.Throws<FieldNotFoundException>(() => user.Locate("VoidField"));
        }

        [Fact]
        public void TestResolveReferences()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var userRoleInfo = schema.Locate(new[] { "User", "Role", "Info" });
            var infoId = new Field(userRoleInfo)
            {
                Name = "InfoId"
            };
            var scope = new Field(userRoleInfo)
            {
                Name = "Scope"
            };
            var infoIdRef = new FieldReference
            {
                SchemaName = "core",
                FieldName = "InfoId"
            };
            var scopeRef = new FieldReference
            {
                SchemaName = "core",
                FieldName = "Scope"
            };
            infoIdRef.EntityPath.AddRange(new[] { "User", "Role", "Info" });
            scopeRef.EntityPath.AddRange(new[] { "User", "Role", "Info" });
            userRoleInfo.PrimaryKey.AddRange(new[] { infoIdRef, scopeRef });
            // Act
            userRoleInfo.ResolveReferences(pass: 0);
            // Assert
            var resolvedFields = userRoleInfo.PrimaryKey.Select(k => k.ResolvedField);
            Assert.Equal(new[] { infoId, scope }, resolvedFields);
        }

        [Fact]
        public void TestResolveReferences_ThrowsForIllegalPrimaryKeys()
        {
            // Arrange
            var schema = CoreSchemaFixture.Create();
            var user = schema.Locate(new[] { "User" });
            var role = schema.Locate(new[] { "Role" });
            _ = new Field(role)
            {
                Name = "RoleId"
            };
            var roleIdRef = new FieldReference
            {
                SchemaName = "core",
                FieldName = "RoleId"
            };
            roleIdRef.EntityPath.Add("Role");
            user.PrimaryKey.Add(roleIdRef);
            // Act & Assert
            Assert.Throws<SemanticException>(() => user.ResolveReferences(pass: 0));
        }
    }
}
