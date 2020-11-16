using Allvis.Kaylee.Analyzer.Enums;
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
            else if (dtype.DTYPE_ROWVERSION() != null)
            {
                Field.Type = FieldType.ROWVERSION;
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
