using Allvis.Kaylee.Analyzer.Enums;
using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using System.Linq;
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
                s =>
                {
                    Assert.Equal("auth", s.Name);
                    Assert.Collection(s.Entities, e =>
                    {
                        Assert.Equal("User", e.Name);
                        Assert.Collection(e.Fields, f =>
                        {
                            Assert.Equal("UserId", f.Name);
                            Assert.Equal(FieldType.GUID, f.Type);
                            Assert.Equal("NEWID()", f.DefaultExpression);
                        }, f =>
                        {
                            Assert.Equal("CreatedAt", f.Name);
                            Assert.Equal(FieldType.DATE, f.Type);
                            Assert.Equal("SYSDATETIMEOFFSET()", f.DefaultExpression);
                        }, f =>
                        {
                            Assert.Equal("FirstName", f.Name);
                            Assert.Equal(FieldType.TEXT, f.Type);
                            Assert.Equal(100, f.Size.Size);
                            Assert.True(f.Nullable);
                        }, f =>
                        {
                            Assert.Equal("LastName", f.Name);
                            Assert.Equal(FieldType.TEXT, f.Type);
                            Assert.Equal(100, f.Size.Size);
                            Assert.True(f.Nullable);
                        }, f =>
                        {
                            Assert.Equal("ContactEmail", f.Name);
                            Assert.Equal(FieldType.TEXT, f.Type);
                            Assert.Equal(254, f.Size.Size);
                            Assert.True(f.Nullable);
                        }, f =>
                        {
                            Assert.Equal("ContactPhone", f.Name);
                            Assert.Equal(FieldType.TEXT, f.Type);
                            Assert.Equal(50, f.Size.Size);
                            Assert.True(f.Nullable);
                        }, f =>
                        {
                            Assert.Equal("Verified", f.Name);
                            Assert.Equal(FieldType.BIT, f.Type);
                            Assert.Equal("0", f.DefaultExpression);
                        }, f =>
                        {
                            Assert.Equal("SuperUser", f.Name);
                            Assert.Equal(FieldType.BIT, f.Type);
                            Assert.Equal("0", f.DefaultExpression);
                        });
                        Assert.Collection(e.PrimaryKey, fr =>
                        {
                            Assert.Equal("UserId", fr.FieldName);
                            Assert.True(fr.IsResolved);
                            Assert.Equal(e.Fields.Single(f => f.Name == "UserId"), fr.ResolvedField);
                        });
                        Assert.Collection(e.Mutations, m =>
                        {
                            Assert.Equal("Name", m.Name);
                            Assert.Collection(m.FieldReferences, fr =>
                            {
                                Assert.Equal("FirstName", fr.FieldName);
                                Assert.True(fr.IsResolved);
                                Assert.Equal(e.Fields.Single(f => f.Name == "FirstName"), fr.ResolvedField);
                            }, fr =>
                            {
                                Assert.Equal("LastName", fr.FieldName);
                                Assert.True(fr.IsResolved);
                                Assert.Equal(e.Fields.Single(f => f.Name == "LastName"), fr.ResolvedField);
                            });
                        }, m =>
                        {
                            Assert.Equal("ContactInformation", m.Name);
                            Assert.Collection(m.FieldReferences, fr =>
                            {
                                Assert.Equal("ContactEmail", fr.FieldName);
                                Assert.True(fr.IsResolved);
                                Assert.Equal(e.Fields.Single(f => f.Name == "ContactEmail"), fr.ResolvedField);
                            }, fr =>
                            {
                                Assert.Equal("ContactPhone", fr.FieldName);
                                Assert.True(fr.IsResolved);
                                Assert.Equal(e.Fields.Single(f => f.Name == "ContactPhone"), fr.ResolvedField);
                            });
                        }, m =>
                        {
                            Assert.Equal("Verified", m.Name);
                            Assert.Collection(m.FieldReferences, fr =>
                            {
                                Assert.Equal("Verified", fr.FieldName);
                                Assert.True(fr.IsResolved);
                                Assert.Equal(e.Fields.Single(f => f.Name == "Verified"), fr.ResolvedField);
                            });
                        });
                    });
                },
                s =>
                {
                    Assert.Equal("tenant", s.Name);
                    Assert.Collection(s.Entities, e =>
                    {
                        Assert.Equal("Tenant", e.Name);
                        Assert.Collection(e.Children, e =>
                        {
                            Assert.Equal("Procedure", e.Name);
                            Assert.Collection(e.Children, e =>
                            {
                                Assert.Equal("Revision", e.Name);
                                Assert.Collection(e.Children, e =>
                                {
                                    Assert.Equal("Execution", e.Name);
                                    Assert.Collection(e.Children, e =>
                                    {
                                        Assert.Equal("Comment", e.Name);
                                        Assert.Collection(e.Children, e =>
                                        {
                                            Assert.Equal("Delivery", e.Name);
                                            Assert.Collection(e.References, r =>
                                            {
                                                Assert.Collection(r.Source, fr =>
                                                {
                                                    Assert.Equal("UserId", fr.FieldName);
                                                    Assert.True(fr.IsResolved);
                                                    Assert.Equal(e.Fields.Single(f => f.Name == "UserId"), fr.ResolvedField);
                                                });
                                                Assert.Collection(r.Target, fr =>
                                                {
                                                    Assert.Equal("UserId", fr.FieldName);
                                                    Assert.True(fr.IsResolved);
                                                    Assert.Equal(s.Ast.Locate("auth", new[] { "User" }).Fields.Single(f => f.Name == "UserId"), fr.ResolvedField);
                                                });
                                            });
                                            Assert.Collection(e.References, r =>
                                            {
                                                Assert.Collection(r.Source, fr =>
                                                {
                                                    Assert.Equal("UserId", fr.FieldName);
                                                    Assert.True(fr.IsResolved);
                                                    Assert.Equal(e.Fields.Single(f => f.Name == "UserId"), fr.ResolvedField);
                                                });
                                                Assert.Collection(r.Target, fr =>
                                                {
                                                    Assert.Equal("UserId", fr.FieldName);
                                                    Assert.True(fr.IsResolved);
                                                    Assert.Equal(s.Ast.Locate("auth", new[] { "User" }).Fields.Single(f => f.Name == "UserId"), fr.ResolvedField);
                                                });
                                            });
                                        }, e =>
                                        {
                                            Assert.Equal("Reaction", e.Name);
                                            Assert.Collection(e.References, r =>
                                            {
                                                Assert.Collection(r.Source, fr =>
                                                {
                                                    Assert.Equal("UserId", fr.FieldName);
                                                    Assert.True(fr.IsResolved);
                                                    Assert.Equal(e.Fields.Single(f => f.Name == "UserId"), fr.ResolvedField);
                                                });
                                                Assert.Collection(r.Target, fr =>
                                                {
                                                    Assert.Equal("UserId", fr.FieldName);
                                                    Assert.True(fr.IsResolved);
                                                    Assert.Equal(s.Ast.Locate("auth", new[] { "User" }).Fields.Single(f => f.Name == "UserId"), fr.ResolvedField);
                                                });
                                            });
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
        }
    }
}
