using Application.Models;
using Application.Models.General;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application
{
    public interface IDishManager
    {
        IEnumerable<Dish> GetDishes(Order<Dish> order);
        ImmutableArray<Dish> SortDishes(IEnumerable<Dish> dishes, SortDirection sortDirection);
    }
}