using Ardalis.SmartEnum;

namespace Application.Models.General
{
    public sealed class SortDirection : SmartEnum<SortDirection>
    {
        public static readonly SortDirection None = new SortDirection(nameof(None), 0);
        public static readonly SortDirection Ascending = new SortDirection(nameof(Ascending), 1);
        public static readonly SortDirection Descending = new SortDirection(nameof(Descending), 2);

        private SortDirection(string name, int value) : base(name, value)
        { }
    }
}
