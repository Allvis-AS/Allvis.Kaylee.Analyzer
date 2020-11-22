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
            var user = new Entity(schema, null, "User", false);
            var role = new Entity(schema, null, "Role", false);
            _ = new Entity(schema, role, "Info", false);
            var userRole = new Entity(schema, user, "Role", false);
            _ = new Entity(schema, userRole, "Info", false);
            return schema;
        }
    }
}
