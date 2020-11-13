using Allvis.Kaylee.Analyzer.Models;

namespace Allvis.Kaylee.Analyzer.Tests.Fixtures
{
    public static class CoreSchemaFixture
    {
        public static Schema Create()
        {
            var ast = new Ast();
            var schema = new Schema(ast)
            {
                Name = "core"
            };
            var user = new Entity(schema, null, "User");
            var role = new Entity(schema, null, "Role");
            _ = new Entity(schema, role, "Info");
            var userRole = new Entity(schema, user, "Role");
            _ = new Entity(schema, userRole, "Info");
            return schema;
        }
    }
}
