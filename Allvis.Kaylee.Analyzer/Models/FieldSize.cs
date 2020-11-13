
namespace Allvis.Kaylee.Analyzer.Models
{
    public class FieldSize
    {
        public bool Max { get; }
        public long Size { get; }

        private FieldSize(bool max, long size) {
            Max = max;
            Size = size;
        }

        public static FieldSize Identity()
        {
            return new FieldSize(false, 0L);
        }

        public static FieldSize ForSize(long size) {
            return new FieldSize(false, size);
        }

        public static FieldSize ForMax() {
            return new FieldSize(true, 0L);
        }
    }
}