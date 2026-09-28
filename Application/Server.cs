using Application.Builders;
using Application.Models;
using Application.Models.General;
using Application.Parsers;
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

        public Server(
            IDishManager dishManager,
            IIntParser parser,
            IMenuBuilder menuBuilder,
            IMenuValidator menuValidator,
            IOrderBuilder orderBuilder)
        {
            DishManager = dishManager;
            Parser = parser;
            MenuBuilder = menuBuilder;
            MenuValidator = menuValidator;
            OrderBuilder = orderBuilder;
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
            try
            {
                var orderedItems = Parser.Parse(orderRequest.Order);

                var availableItems = GetAvailableItems(orderRequest.PartOfTheDay, orderedItems);

                var order = OrderBuilder.Build(availableItems);

                var availableDishes = DishManager._GetDishes(order);
                
                var sortedDishes = DishManager._SortDishes(availableDishes, SortDirection.Ascending);

                // TODO: Refactor
                return order.ToString();

                //string returnValue = FormatOutput(dishes);
                //return returnValue;
            }
            catch (ApplicationException)
            {
                return "error";
            }
        }


        private Order ParseOrder(string unparsedOrder)
        {
            var returnValue = new Order
            {
                Dishes = new List<int>()
            };

            var orderItems = unparsedOrder.Split(',');
            foreach (var orderItem in orderItems)
            {
                if (int.TryParse(orderItem, out int parsedOrder))
                {
                    returnValue.Dishes.Add(parsedOrder);
                }
                else
                {
                    throw new ApplicationException("Order needs to be comma separated list of numbers");
                }
            }
            return returnValue;
        }

        private string FormatOutput(List<Dish> dishes)
        {
            var returnValue = "";

            foreach (var dish in dishes)
            {
                returnValue = returnValue + string.Format(",{0}{1}", dish.DishName, GetMultiple(dish.Count));
            }

            if (returnValue.StartsWith(","))
            {
                returnValue = returnValue.TrimStart(',');
            }

            return returnValue;
        }

        private object GetMultiple(int count)
        {
            if (count > 1)
            {
                return string.Format("(x{0})", count);
            }
            return "";
        }
    }
}
