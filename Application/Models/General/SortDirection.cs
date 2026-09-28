using Ardalis.SmartEnum;

namespace Application.Models.General
{
    public sealed class SortDirection : SmartEnum<SortDirection>
    {
        public static SortDirection None { get; } = new SortDirection(nameof(None), 0);
        public static SortDirection Ascending { get; } = new SortDirection(nameof(Ascending), 1);
        public static SortDirection Descending { get; } = new SortDirection(nameof(Descending), 2);

        private SortDirection(string name, int value) : base(name, value)
        { }
    }
}
