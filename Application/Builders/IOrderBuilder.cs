using Application.Models;
using System.Collections.Generic;

namespace Application.Builders
{
    public interface IOrderBuilder : IBuilder<Order<Dish>, IEnumerable<DishName>> { }
}
