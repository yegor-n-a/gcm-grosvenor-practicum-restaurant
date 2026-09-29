using Application.Interfaces.General;
using Ardalis.SmartEnum;

namespace Application.Models
{
    public sealed class PartOfTheDay : SmartEnum<PartOfTheDay>, IDefaultPrimitive<PartOfTheDay>
    {
        public static readonly PartOfTheDay None = new PartOfTheDay(nameof(None), 0);
        public static readonly PartOfTheDay Morning = new PartOfTheDay(nameof(Morning), 1);
        public static readonly PartOfTheDay Afternoon = new PartOfTheDay(nameof(Afternoon), 2);
        public static readonly PartOfTheDay Evening = new PartOfTheDay(nameof(Evening), 3);

        public PartOfTheDay Default { get; set; } = None;

        private PartOfTheDay(string name, int value) : base(name, value)
        { }
    }
}
