using Application.Extensions;
using Application.Models;
using Application.Models.General;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Application.Sorters
{
    public class OrderSorter : IOrderSorter<DishDescriptor>
    {
        public ImmutableSortedSet<DishDescriptor> Sort(IEnumerable<DishDescriptor> source, SortDirection sortDirection)
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
                    return source.OrderBy(x => x.Position).ToImmutableSortedSet();
                case nameof(SortDirection.Descending):
                    return source.OrderByDescending(x => x.Position).ToImmutableSortedSet();
                default:
                    throw new ArgumentOutOfRangeException(nameof(sortDirection), "Invalid sort direction");
            }
        }
    }
}
