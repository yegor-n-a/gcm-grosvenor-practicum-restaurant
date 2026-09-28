using Application.Constraints;
using Application.Interfaces.General;

namespace Application.Models
{
    public interface IDishDescriptor : INamedItem<DishName>, ITypedItem<DishType>, IPositionedItem<decimal?>
    {
        public DishConstraints Constraints { get; set; }
    }
}
