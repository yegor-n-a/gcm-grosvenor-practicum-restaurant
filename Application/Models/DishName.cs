using Ardalis.SmartEnum;

namespace Application.Models
{
    public sealed class DishName : SmartEnum<DishName>
    {
        public static DishName None { get; } = new DishName(nameof(None), 0);
        public static DishName Egg { get; } = new DishName(nameof(Egg), 1);
        public static DishName Toast { get; } = new DishName(nameof(Toast), 2);
        public static DishName Coffee { get; } = new DishName(nameof(Coffee), 3);
        public static DishName Steak { get; } = new DishName(nameof(Steak), 4);
        public static DishName Potato { get; } = new DishName(nameof(Potato), 5);
        public static DishName Wine { get; } = new DishName(nameof(Wine), 6);
        public static DishName Cake { get; } = new DishName(nameof(Cake), 7);

        private DishName(string name, int value) : base(name, value)
        { }
    }
}
