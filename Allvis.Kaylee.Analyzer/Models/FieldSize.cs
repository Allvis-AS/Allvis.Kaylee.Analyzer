using System;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class FieldSize
    {
        public long Size { get; }
        public long Precision { get; }

        public bool IsMax => Size == -1;

        private FieldSize(long size, long precision)
        {
            Size = size;
            Precision = precision;
        }

        public static FieldSize Identity()
        {
            return new FieldSize(0L, 0L);
        }

        public static FieldSize ForSize(long size, long precision = 0)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Must be 0 or greater");
            }
            if (precision < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), "Must be 0 or greater");
            }
            return new FieldSize(size, precision);
        }

        public static FieldSize ForMax()
        {
            return new FieldSize(-1L, 0L);
        }
    }
}