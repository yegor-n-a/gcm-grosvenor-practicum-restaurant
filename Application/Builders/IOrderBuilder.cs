using Application.Models;
using System.Collections.Generic;

namespace Application.Builders
{
    public interface IOrderBuilder : IBuilder<_Order<_Dish>, IEnumerable<int>> { }
}
