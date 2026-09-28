using Application.Models.General;
using Application.Constraints;

namespace Application.Models
{
    public class DishDescriptor : NamedItem<DishName>, IDishDescriptor
    {
        public DishType Type { get; set; }
        public decimal? Position { get; set; }
        public DishConstraints Constraints { get; set; }
    }
}
