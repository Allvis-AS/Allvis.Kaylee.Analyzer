using System;

namespace Allvis.Kaylee.Analyzer.Models
{
    public class FieldSize
    {
        public long Size { get; }

        public bool IsMax => Size == -1;

        private FieldSize(long size)
        {
            Size = size;
        }

        public static FieldSize Identity()
        {
            return new FieldSize(0L);
        }

        public static FieldSize ForSize(long size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Must be 0 or greater");
            }
            return new FieldSize(size);
        }

        public static FieldSize ForMax()
        {
            return new FieldSize(-1L);
        }
    }
}