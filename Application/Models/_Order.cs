using Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace Application.Models
{
    public class _Order<T> : IOrder<T>
    {
        public ImmutableSortedSet<T> Dishes { get; } = ImmutableSortedSet<T>.Empty;

        public _Order(ImmutableSortedSet<T> dishes)
        {
            if (dishes.IsNullOrEmpty())
                throw new ArgumentOutOfRangeException(nameof(dishes), "Order cannot be empty");

            Dishes = dishes;
        }
    }
}
