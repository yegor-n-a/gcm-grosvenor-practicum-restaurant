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
        private static IComparer<Dish> Comparer { get; } = Comparer<Dish>.Create((first, second) =>
        {
            var positionComparison = Nullable.Compare(first?.Position, second?.Position);

            return positionComparison != 0
                ? positionComparison
                : string.Compare(first?.Name?.Name, second?.Name?.Name, StringComparison.Ordinal);
        });

        public ImmutableSortedSet<Dish> Sort(IEnumerable<Dish> source, SortDirection sortDirection)
        {
            if (source.IsNullOrEmpty())
                throw new ArgumentOutOfRangeException("Sorting failed: collection must contain at least one element");

            var maxPosition = source.Max(x => x.Position) ?? 0;

            source = source.Select(item =>
            {
                if (item.Position == null) item.Position = ++maxPosition;

                return item;
            });

            switch (sortDirection.Name)
            {
                case nameof(SortDirection.Ascending):
                    return source.OrderBy(x => x.Position).ToImmutableSortedSet(Comparer);
                case nameof(SortDirection.Descending):
                    return source.OrderByDescending(x => x.Position).ToImmutableSortedSet(Comparer);
                default:
                    throw new ArgumentOutOfRangeException(nameof(sortDirection), "Invalid sort direction");
            }
        }
    }
}
