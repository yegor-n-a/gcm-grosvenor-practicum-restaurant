using Ardalis.SmartEnum;

namespace Application.Models
{
    public sealed class PartOfTheDay : SmartEnum<PartOfTheDay>
    {
        public static PartOfTheDay None { get; } = new PartOfTheDay(nameof(None), 0);
        public static PartOfTheDay Morning { get; } = new PartOfTheDay(nameof(Morning), 1);
        public static PartOfTheDay Afternoon { get; } = new PartOfTheDay(nameof(Afternoon), 2);
        public static PartOfTheDay Evening { get; } = new PartOfTheDay(nameof(Evening), 3);

        private PartOfTheDay(string name, int value) : base(name, value)
        { }
    }
}
