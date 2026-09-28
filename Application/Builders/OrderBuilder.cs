using Application.Models;
using Application.Models.General;
using Application.Parsers;
using Application.Sorters;
using System.Collections.Generic;

namespace Application.Builders
{
    public class OrderBuilder : IOrderBuilder
    {
        private IIntParser Parser { get; }
        private IDishDescriptorBuilder DishDescriptorBuilder { get; }
        private IOrderSorter<_Dish> Sorter { get; }

        public _Order<_Dish> Build(string source)
        {
            var dishIds = Parser.Parse(source);

            var dishes = new List<_Dish>();

            foreach (var dishId in dishIds)
            {
                var dishDescriptor = DishDescriptorBuilder.Build(dishId);

                // TODO: Validate dishDescritor

                // TODO: calculate and assign count

                var dish = new _Dish
                {
                    Name = dishDescriptor.Name,
                    Type = dishDescriptor.Type,
                    Position = dishDescriptor.Position,
                    Count = 1
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
