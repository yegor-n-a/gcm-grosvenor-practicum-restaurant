using Application.Models;
using Application.Models.General;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application
{

    public interface IDishManager
    {
        /// <summary>
        /// Constructs a list of dishes, each dish with a name and a count
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        List<Dish> GetDishes(Order order);
        IEnumerable<_Dish> _GetDishes(_Order<_Dish> order);
        ImmutableSortedSet<_Dish> _SortDishes(IEnumerable<_Dish> dishes, SortDirection sortDirection);
    }
}