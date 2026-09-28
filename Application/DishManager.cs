using Application.Validators;
using Application.Models;
using Application.Models.General;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Application.Sorters;

namespace Application
{
    public class DishManager : IDishManager
    {
        public DishValidator DishValidator { get; }
        public IDishSorter DishSorter { get; }

        public DishManager(
            DishValidator dishValidator,
            IDishSorter dishSorter)
        {
            DishValidator = dishValidator;
            DishSorter = dishSorter;
        }

        public IEnumerable<_Dish> _GetDishes(_Order<_Dish> order)
        {
            foreach (var dish in order.Dishes)
            {
                var validatedDish = DishValidator.Validate(dish);

                if (!validatedDish.IsValid)
                {
                    foreach (var error in validatedDish.Errors)
                    {
                        Console.WriteLine($"Invalid dish '{dish.Name}'. Error: {error.ErrorMessage}");
                    }
                }
                else
                {
                    yield return dish;
                }
            }
        }

        public ImmutableSortedSet<_Dish> _SortDishes(IEnumerable<_Dish> dishes, SortDirection sortDirection)
        {
            return DishSorter.Sort(dishes, sortDirection);
        }

        /// <summary>
        /// Takes an Order object, sorts the orders and builds a list of dishes to be returned. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(Order order)
        {
            var returnValue = new List<Dish>();
            order.Dishes.Sort();
            foreach (var dishType in order.Dishes)
            {
                AddOrderToList(dishType, returnValue);
            }
            return returnValue;
        }

        /// <summary>
        /// Takes an int, representing an order type, tries to find it in the list.
        /// If the dish type does not exist, add it and set count to 1
        /// If the type exists, check if multiples are allowed and increment that instances count by one
        /// else throw error
        /// </summary>
        /// <param name="order">int, represents a dishtype</param>
        /// <param name="returnValue">a list of dishes, - get appended to or changed </param>
        private void AddOrderToList(int order, List<Dish> returnValue)
        {
            string orderName = GetOrderName(order);

            var existingOrder = returnValue.SingleOrDefault(x => x.DishName == orderName);

            if (existingOrder == null)
            {
                returnValue.Add(new Dish
                {
                    DishName = orderName,
                    Count = 1
                });
            }
            else if (IsMultipleAllowed(order))
            {
                existingOrder.Count++;
            }
            else
            {
                throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", orderName));
            }
        }

        private string GetOrderName(int order)
        {
            switch (order)
            {
                case 1:
                    return "steak";
                case 2:
                    return "potato";
                case 3:
                    return "wine";
                case 4:
                    return "cake";
                default:
                    throw new ApplicationException("Order does not exist");

            }
        }

        private bool IsMultipleAllowed(int order)
        {
            switch (order)
            {
                case 2:
                    return true;
                default:
                    return false;

            }
        }
    }
}