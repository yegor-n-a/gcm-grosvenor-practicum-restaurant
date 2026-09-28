using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Application.Extensions;

namespace Application.Models
{
    public class SortedOrder<T> : ISortedOrder<T>
    {
        public ImmutableSortedSet<T> Dishes { get; } = ImmutableSortedSet<T>.Empty;

        public SortedOrder(IEnumerable<T> dishes)
        {
            if (dishes.IsNullOrEmpty())
                throw new ArgumentOutOfRangeException(nameof(dishes), "Order cannot be empty");

            Dishes = ImmutableSortedSet.CreateRange(dishes);
        }
    }
}
