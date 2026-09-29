using Application.Interfaces.General;
using Ardalis.SmartEnum;

namespace Application.Models
{
    public sealed class DishName : SmartEnum<DishName>, IDefaultPrimitive<DishName>
    {
        public static readonly DishName None = new DishName(nameof(None), 0);
        public static readonly DishName Egg = new DishName(nameof(Egg), 1);
        public static readonly DishName Toast = new DishName(nameof(Toast), 2);
        public static readonly DishName Coffee = new DishName(nameof(Coffee), 3);
        public static readonly DishName Steak = new DishName(nameof(Steak), 4);
        public static readonly DishName Potato = new DishName(nameof(Potato), 5);
        public static readonly DishName Wine = new DishName(nameof(Wine), 6);
        public static readonly DishName Cake = new DishName(nameof(Cake), 7);

        public DishName Default { get; set; } = None;

        private DishName(string name, int value) : base(name, value)
        { }
    }
}
