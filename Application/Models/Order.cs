using Application.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Models
{
    public class Order<T> : IOrder<T>
    {
        public ImmutableArray<T> Dishes { get; } = ImmutableArray<T>.Empty;

        public Order(IEnumerable<T> dishes)
        {
            if (dishes.IsNullOrEmpty())
                throw new ArgumentOutOfRangeException(nameof(dishes), "Order cannot be empty");

            Dishes = ImmutableArray.CreateRange(dishes);
        }
    }
}
