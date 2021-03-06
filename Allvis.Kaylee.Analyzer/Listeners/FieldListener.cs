﻿using Allvis.Kaylee.Analyzer.Enums;
using Allvis.Kaylee.Analyzer.Models;
using Antlr4.Runtime.Misc;
using System;
using System.Linq;

namespace Allvis.Kaylee.Analyzer.Listeners
{
    public class FieldListener : KayleeParserBaseListener
    {
        public Field Field { get; }

        public FieldListener(Entity entity)
        {
            Field = new Field(entity);
        }

        public override void EnterField([NotNull] KayleeParser.FieldContext context)
        {
            Field.Name = context.IDENTIFIER().GetText();
            Field.Nullable = context.QUESTION_MARK() != null;
            ParseDataType(context.dtype());
            var fieldBody = context.fieldBody();
            if (fieldBody != null)
            {
                ParseComputed(fieldBody);
                ParseDefaultExpression(fieldBody);
            }
        }

        private void ParseDataType(KayleeParser.DtypeContext dtype)
        {
            if (dtype.DTYPE_BIT() != null)
            {
                Field.Type = FieldType.BIT;
            }
            else if (dtype.DTYPE_TINYINT() != null)
            {
                Field.Type = FieldType.TINYINT;
            }
            else if (dtype.DTYPE_INT() != null)
            {
                Field.Type = FieldType.INT;
                Field.AutoIncrement = dtype.dtypeIntAutoIncrement() != null;
            }
            else if (dtype.DTYPE_BIGINT() != null)
            {
                Field.Type = FieldType.BIGINT;
                Field.AutoIncrement = dtype.dtypeBigintAutoIncrement() != null;
            }
            else if (dtype.DTYPE_DECIMAL() != null)
            {
                Field.Type = FieldType.DECIMAL;
                var size = dtype.dTypeDecimalSize().GetText();
                var precision = dtype.dtypeDecimalPrecision().GetText();
                Field.Size = FieldSize.ForSize(long.Parse(size), long.Parse(precision));
            }
            else if (dtype.DTYPE_CHAR() != null)
            {
                Field.Type = FieldType.CHAR;
            }
            else if (dtype.DTYPE_TEXT() != null)
            {
                Field.Type = FieldType.TEXT;
                var size = dtype.dtypeTextSize().GetText();
                if (size == "MAX")
                {
                    Field.Size = FieldSize.ForMax();
                }
                else
                {
                    Field.Size = FieldSize.ForSize(long.Parse(size));
                }
            }
            else if (dtype.DTYPE_GUID() != null)
            {
                Field.Type = FieldType.GUID;
            }
            else if (dtype.DTYPE_DATE() != null)
            {
                Field.Type = FieldType.DATE;
            }
            else if (dtype.DTYPE_VARBINARY() != null)
            {
                Field.Type = FieldType.VARBINARY;
                var size = dtype.dtypeVarbinarySize().GetText();
                if (size == "MAX")
                {
                    Field.Size = FieldSize.ForMax();
                }
                else
                {
                    Field.Size = FieldSize.ForSize(long.Parse(size));
                }
            }
            else if (dtype.DTYPE_BINARY() != null)
            {
                Field.Type = FieldType.BINARY;
                var size = dtype.dtypeBinarySize().GetText();
                Field.Size = FieldSize.ForSize(long.Parse(size));
            }
            else if (dtype.DTYPE_ROWVERSION() != null)
            {
                Field.Type = FieldType.ROWVERSION;
            }
        }

        private void ParseComputed(KayleeParser.FieldBodyContext body)
        {
            var parameter = body.fieldParameterComputed().FirstOrDefault();
            if (parameter != null)
            {
                var value = parameter.fieldParameterComputedValue();
                Field.Computed = bool.Parse(value.BOOLEAN().GetText());
            }
        }

        private void ParseDefaultExpression(KayleeParser.FieldBodyContext body)
        {
            var parameter = body.fieldParameterDefault().FirstOrDefault();
            if (parameter != null)
            {
                var value = parameter.fieldParameterDefaultValue();
                Field.DefaultExpression = value.GetText();
            }
        }
    }
}
