using Application.Interfaces.General;
using Ardalis.SmartEnum;

namespace Application.Models
{
    public sealed class DishType : SmartEnum<DishType>, IDefaultPrimitive<DishType>
    {
        public static DishType None { get; } = new DishType(nameof(None), 0);
        public static DishType Entree { get; } = new DishType(nameof(Entree), 1);
        public static DishType Side { get; } = new DishType(nameof(Side), 2);
        public static DishType Drink { get; } = new DishType(nameof(Drink), 3);
        public static DishType Dessert { get; } = new DishType(nameof(Dessert), 4);

        public DishType Default { get; set; } = None;

        private DishType(string name, int value) : base(name, value)
        { }
    }
}
