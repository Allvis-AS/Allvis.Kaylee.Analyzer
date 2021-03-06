﻿using Allvis.Kaylee.Analyzer.Enums;
using Allvis.Kaylee.Analyzer.Tests.Fixtures;
using NuGet.Frameworks;
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
            var ast = KayleeHelper.Parse(tModel);
            // Assert
            Assert.Collection(ast.Schemata,
                s =>
                {
                    Assert.Equal("auth", s.Name);
                    Assert.Collection(s.Entities, e =>
                    {
                        Assert.Equal("User", e.Name);
                        Assert.False(e.IsQuery);
                        Assert.Collection(e.Fields, f =>
                        {
                            Assert.Equal("UserId", f.Name);
                            Assert.Equal(FieldType.GUID, f.Type);
                            Assert.Equal("NEWID()", f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("CreatedAt", f.Name);
                            Assert.Equal(FieldType.DATE, f.Type);
                            Assert.Equal("SYSDATETIMEOFFSET()", f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("FirstName", f.Name);
                            Assert.Equal(FieldType.TEXT, f.Type);
                            Assert.Equal(100, f.Size.Size);
                            Assert.Equal(0, f.Size.Precision);
                            Assert.Null(f.DefaultExpression);
                            Assert.True(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("LastName", f.Name);
                            Assert.Equal(FieldType.TEXT, f.Type);
                            Assert.Equal(100, f.Size.Size);
                            Assert.Equal(0, f.Size.Precision);
                            Assert.Null(f.DefaultExpression);
                            Assert.True(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("ContactEmail", f.Name);
                            Assert.Equal(FieldType.TEXT, f.Type);
                            Assert.Equal(254, f.Size.Size);
                            Assert.Equal(0, f.Size.Precision);
                            Assert.Null(f.DefaultExpression);
                            Assert.True(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("ContactPhone", f.Name);
                            Assert.Equal(FieldType.TEXT, f.Type);
                            Assert.Equal(50, f.Size.Size);
                            Assert.Equal(0, f.Size.Precision);
                            Assert.Null(f.DefaultExpression);
                            Assert.True(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("Verified", f.Name);
                            Assert.Equal(FieldType.BIT, f.Type);
                            Assert.Equal("0", f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("SuperUser", f.Name);
                            Assert.Equal(FieldType.BIT, f.Type);
                            Assert.Equal("0", f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("NormalizedContactEmail", f.Name);
                            Assert.Equal(FieldType.TEXT, f.Type);
                            Assert.Equal(254, f.Size.Size);
                            Assert.Equal(0, f.Size.Precision);
                            Assert.Null(f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.True(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("Hash", f.Name);
                            Assert.Equal(FieldType.BINARY, f.Type);
                            Assert.Equal(128, f.Size.Size);
                            Assert.Equal(0, f.Size.Precision);
                            Assert.Null(f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("Picture", f.Name);
                            Assert.Equal(FieldType.VARBINARY, f.Type);
                            Assert.Equal(8192, f.Size.Size);
                            Assert.Equal(0, f.Size.Precision);
                            Assert.Null(f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("CV", f.Name);
                            Assert.Equal(FieldType.VARBINARY, f.Type);
                            Assert.True(f.Size.IsMax);
                            Assert.Null(f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("RAM4", f.Name);
                            Assert.Equal(FieldType.BIGINT, f.Type);
                            Assert.Null(f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.False(f.Computed);
                        }, f =>
                        {
                            Assert.Equal("Price", f.Name);
                            Assert.Equal(FieldType.DECIMAL, f.Type);
                            Assert.Equal(19, f.Size.Size);
                            Assert.Equal(4, f.Size.Precision);
                            Assert.Null(f.DefaultExpression);
                            Assert.False(f.Nullable);
                            Assert.False(f.Computed);
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
                        Assert.False(e.IsQuery);
                        Assert.Collection(e.Children, e =>
                        {
                            Assert.Equal("Task", e.Name);
                            Assert.True(e.IsQuery);
                            Assert.Collection(e.PrimaryKey, fr =>
                            {
                                Assert.Equal("TaskId", fr.FieldName);
                                Assert.Equal(e.Fields.Single(f => f.Name == "TaskId"), fr.ResolvedField);
                            });
                        }, e =>
                        {
                            Assert.Equal("Procedure", e.Name);
                            Assert.False(e.IsQuery);
                            Assert.Collection(e.Children, e =>
                            {
                                Assert.Equal("Revision", e.Name);
                                Assert.False(e.IsQuery);
                                Assert.Collection(e.Children, e =>
                                {
                                    Assert.Equal("Execution", e.Name);
                                    Assert.False(e.IsQuery);
                                    Assert.Collection(e.Children, e =>
                                    {
                                        Assert.Equal("Comment", e.Name);
                                        Assert.False(e.IsQuery);
                                        Assert.Collection(e.Children, e =>
                                        {
                                            Assert.Equal("Delivery", e.Name);
                                            Assert.False(e.IsQuery);
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
                                            Assert.False(e.IsQuery);
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
                                            Assert.Collection(e.UniqueKeys, k =>
                                            {
                                                Assert.Collection(k.FieldReferences, fr =>
                                                {
                                                    Assert.Equal("CommentId", fr.FieldName);
                                                    Assert.True(fr.IsResolved);
                                                    Assert.Equal(e.Parent.Fields.Single(f => f.Name == "CommentId"), fr.ResolvedField);
                                                }, fr =>
                                                {
                                                    Assert.Equal("Emoji", fr.FieldName);
                                                    Assert.True(fr.IsResolved);
                                                    Assert.Equal(e.Fields.Single(f => f.Name == "Emoji"), fr.ResolvedField);
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
