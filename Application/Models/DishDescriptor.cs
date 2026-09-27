using Application.Helpers;
using Application.Interfaces.General;
using Application.Models.General;

namespace Application.Models
{
    public class DishDescriptor : NamedItem<DishName>, IPositionedItem<decimal?>
    {
        public DishType Type { get; set; }
        public decimal? Position { get; set; }

        //public DishDescriptor(string name) { }
    }

    public class DishDescriptorBuilder : IBuilder<DishDescriptor, string>
    {
        public DishDescriptor Build(string source)
        {
            var dishName = DishNameAssistant.GetName(source);

            if (dishName == DishName.None) return null;

            var dishType = DishNameAssistant.GetType(dishName);

            if (dishType == DishType.None) return null;

            var position = DishTypeAssistant.GetPosition(dishType);

            if (position == null) return null;

            return new DishDescriptor
            {
                Name = dishName,
                Type = dishType,
                Position = position
            };
        }
    }
}
