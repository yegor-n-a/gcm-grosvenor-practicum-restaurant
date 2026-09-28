using Application.Interfaces.General;
using Application.Constraints;

namespace Application.Models
{
    public interface IDishDescriptor : INamedItem<DishName>, ITypedItem<DishType>, IPositionedItem<decimal?>
    {
        public DishConstraints Constraints { get; set; }
    }
}
