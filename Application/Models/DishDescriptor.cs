using Application.Models.General;

namespace Application.Models
{
    public class DishDescriptor : NamedItem<DishName>, IDishDescriptor
    {
        public DishType Type { get; set; }
        public decimal? Position { get; set; }
    }
}
