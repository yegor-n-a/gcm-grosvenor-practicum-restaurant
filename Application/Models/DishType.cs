using Application.Interfaces.General;
using Ardalis.SmartEnum;

namespace Application.Models
{
    public sealed class DishType : SmartEnum<DishType>, IDefaultPrimitive<DishType>
    {
        public static readonly DishType None = new DishType(nameof(None), 0);
        public static readonly DishType Entree = new DishType(nameof(Entree), 1);
        public static readonly DishType Side = new DishType(nameof(Side), 2);
        public static readonly DishType Drink = new DishType(nameof(Drink), 3);
        public static readonly DishType Dessert = new DishType(nameof(Dessert), 4);

        public DishType Default { get; set; } = None;

        private DishType(string name, int value) : base(name, value)
        { }
    }
}
