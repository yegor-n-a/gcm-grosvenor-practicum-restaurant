using Application.Models;
using Application.Models.General;
using Application.Parsers;
using Application.Sorters;
using System.Collections.Generic;
using System.Linq;

namespace Application.Builders
{
    public class OrderBuilder : IOrderBuilder
    {
        private IIntParser Parser { get; }
        private IDishDescriptorBuilder DishDescriptorBuilder { get; }
        private IOrderSorter<_Dish> Sorter { get; }

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

        public _Order<_Dish> Build(string source)
        {
            var dishIds = Parser.Parse(source);

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

            var sortedDishes = Sorter.Sort(dishes, SortDirection.Ascending);

            return new _Order<_Dish>(sortedDishes);
        }

        public OrderBuilder(
            IIntParser parser,
            IDishDescriptorBuilder dishDescriptorBuilder,
            IOrderSorter<_Dish> sorter)
        {
            Parser = parser;
            DishDescriptorBuilder = dishDescriptorBuilder;
            Sorter = sorter;
        }
    }
}
