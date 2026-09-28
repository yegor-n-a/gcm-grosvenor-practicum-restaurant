using Application.Builders;
using Application.Models;
using Application.Models.General;
using Application.Parsers;
using Application.Printers;
using Application.Validators;
using System;
using System.Collections.Generic;

namespace Application
{
    public class Server : IServer
    {
        private IDishManager DishManager { get; }
        public IIntParser Parser { get; }
        public IMenuBuilder MenuBuilder { get; }
        public IMenuValidator MenuValidator { get; }
        public IOrderBuilder OrderBuilder { get; }
        public IDishPrinter DishPrinter { get; }

        public Server(
            IDishManager dishManager,
            IIntParser parser,
            IMenuBuilder menuBuilder,
            IMenuValidator menuValidator,
            IOrderBuilder orderBuilder,
            IDishPrinter dishPrinter)
        {
            DishManager = dishManager;
            Parser = parser;
            MenuBuilder = menuBuilder;
            MenuValidator = menuValidator;
            OrderBuilder = orderBuilder;
            DishPrinter = dishPrinter;
        }

        private IEnumerable<int> GetAvailableItems(string menuName, IEnumerable<int> orderedItemIds)
        {
            var menu = MenuBuilder.Build(menuName);

            var validatedItems = MenuValidator.Validate(menu, orderedItemIds);

            var availableItems = new List<int>();

            foreach (var validatedItem in validatedItems)
            {
                if (!validatedItem.Value.IsValid)
                {
                    foreach (var error in validatedItem.Value.Errors)
                    {
                        Console.WriteLine(error);
                    }
                }
                else
                {
                    availableItems.Add(validatedItem.Key);
                }
            }

            return availableItems;
        }

        public string TakeOrder(OrderRequest orderRequest)
        {
            var orderedItems = Parser.Parse(orderRequest.Order);

            var availableItems = GetAvailableItems(orderRequest.PartOfTheDay, orderedItems);

            var order = OrderBuilder.Build(availableItems);

            var availableDishes = DishManager.GetDishes(order);

            var sortedDishes = DishManager.SortDishes(availableDishes, SortDirection.Ascending);

            return DishPrinter.Print(sortedDishes);
        }
    }
}
