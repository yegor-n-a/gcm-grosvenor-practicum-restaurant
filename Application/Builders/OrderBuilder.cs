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

        private IEnumerable<KeyValuePair<DishName, int>> AggregateDishes(IEnumerable<DishName> dishNames)
        {
            var dishAggregates = new Dictionary<DishName, int>();

            foreach (var dishName in dishNames)
            {
                if (dishAggregates.ContainsKey(dishName))
                    dishAggregates[dishName]++;
                else
                    dishAggregates[dishName] = 1;
            }

            return dishAggregates;
        }

        public Order<Dish> Build(IEnumerable<DishName> dishNames)
        {
            if (dishNames.IsNullOrEmpty())
                throw new ArgumentOutOfRangeException(nameof(dishNames), "Order cannot be empty");

            var aggregatedDishes = AggregateDishes(dishNames);
            var dishes = new List<Dish>(aggregatedDishes.Count());

            foreach (var dishAggregate in aggregatedDishes)
            {
                var dishName = dishAggregate.Key;
                var dishType = DishDescriptorBuilder.BuildType(dishName);

                var dish = new Dish
                {
                    Name = dishName,
                    Type = dishType,
                    Position = DishDescriptorBuilder.BuildPosition(dishType),
                    Constraints = DishDescriptorBuilder.BuildConstraints(dishName),
                    Count = dishAggregate.Value
                };

                dishes.Add(dish);
            }

            return new Order<Dish>(dishes);
        }
    }
}
