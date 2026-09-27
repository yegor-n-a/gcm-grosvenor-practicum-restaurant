using Application.Interfaces.General;
using Application.Models.General;

namespace Application.Models
{
    public class DishDescriptor : NamedItem<string>, IPositionedItem<decimal?>
    {
        public DishType Type { get; set; }
        public decimal? Position { get; set; }

        public DishDescriptor(string name) { }
    }
}
