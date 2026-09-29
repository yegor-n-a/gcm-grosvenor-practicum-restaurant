using Application.Builders;
using Application.Exceptions;
using Application.Models;
using Application.Models.General;
using Application.Parsers;
using Application.Printers;
using Application.Validators;
using System.Collections.Generic;
using System.Linq;

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

        private string DefaultErrorMessage => "error";

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

        private IEnumerable<DishName> GetAvailableItems(string menuName, IEnumerable<int> orderedItemIds)
        {
            var menu = MenuBuilder.Build(menuName);
            var orderedItems = orderedItemIds.ToList();

            var validatedItems = MenuValidator.Validate(menu, orderedItems);

            foreach (var validatedItem in validatedItems)
            {
                if (!validatedItem.Value.IsValid)
                {
                    throw new InvalidOrderException($"Dish # {validatedItem.Key} is not available for order.");
                }
            }

            return orderedItems.Select(itemId => menu.Items[itemId]);
        }

        public string TakeOrder(OrderRequest orderRequest)
        {
            try
            {
                var orderedItems = Parser.Parse(orderRequest.Order);

                var availableItems = GetAvailableItems(orderRequest.PartOfTheDay, orderedItems);

                var order = OrderBuilder.Build(availableItems);

                var availableDishes = DishManager.GetDishes(order);

                var sortedDishes = DishManager.SortDishes(availableDishes, SortDirection.Ascending);

                return DishPrinter.Print(sortedDishes);
            }
            catch (InvalidOrderException)
            {
                return DefaultErrorMessage;
            }
        }
    }
}
