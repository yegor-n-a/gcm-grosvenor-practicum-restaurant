using Application.Extensions;
using Application.Models;
using Application.Models.General;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Application.Sorters
{
    public class DishSorter : IDishSorter
    {
        public ImmutableArray<Dish> Sort(IEnumerable<Dish> source, SortDirection sortDirection)
        {
            if (source.IsNullOrEmpty())
                throw new ArgumentOutOfRangeException("Sorting failed: collection must contain at least one element");

            var dishes = source.ToList();
            var maxPosition = dishes.Max(x => x.Position) ?? 0;

            var positionedDishes = dishes
                .Select(dish => new
                {
                    Dish = dish,
                    Position = dish.Position ?? ++maxPosition
                })
                .ToList();

            switch (sortDirection.Name)
            {
                case nameof(SortDirection.Ascending):
                    return positionedDishes.OrderBy(x => x.Position).Select(x => x.Dish).ToImmutableArray();
                case nameof(SortDirection.Descending):
                    return positionedDishes.OrderByDescending(x => x.Position).Select(x => x.Dish).ToImmutableArray();
                default:
                    throw new ArgumentOutOfRangeException(nameof(sortDirection), "Invalid sort direction");
            }
        }
    }
}
