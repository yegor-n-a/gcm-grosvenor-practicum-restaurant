using Application.Extensions;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Builders
{
    public class OrderBuilder : IOrderBuilder
    {
        private IDishDescriptorBuilder DishDescriptorBuilder { get; }

        public OrderBuilder(
            IDishDescriptorBuilder dishDescriptorBuilder)
        {
            DishDescriptorBuilder = dishDescriptorBuilder;
        }

        private IEnumerable<DishAggregate> AggregateDishes(IEnumerable<int> dishIds)
        {
            var dishAggregates = new Dictionary<int, DishAggregate>();

            foreach (var dishId in dishIds)
            {
                if (dishAggregates.ContainsKey(dishId))
                    dishAggregates[dishId].Count++;
                else
                    dishAggregates[dishId] = new DishAggregate { Id = dishId, Count = 1 };
            }

            return dishAggregates.Values;
        }

        public _Order<_Dish> Build(IEnumerable<int> dishIds)
        {
            if (dishIds.IsNullOrEmpty())
                throw new ArgumentOutOfRangeException(nameof(dishIds), "Order cannot be empty");

            var aggregatedDishes = AggregateDishes(dishIds);
            var dishes = new List<_Dish>(aggregatedDishes.Count());

            foreach (var dishAggregate in aggregatedDishes)
            {
                var dishDescriptor = DishDescriptorBuilder.Build(dishAggregate.Id);

                var dish = new _Dish
                {
                    Name = dishDescriptor.Name,
                    Type = dishDescriptor.Type,
                    Position = dishDescriptor.Position,
                    Count = dishAggregate.Count
                };

                dishes.Add(dish);
            }

            return new _Order<_Dish>(dishes);
        }
    }
}
