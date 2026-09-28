using Application.Models;
using Application.Models.General;
using Application.Sorters;
using Application.Validators;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

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

        public IEnumerable<Dish> GetDishes(Order<Dish> order)
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

        public ImmutableSortedSet<Dish> SortDishes(IEnumerable<Dish> dishes, SortDirection sortDirection)
        {
            return DishSorter.Sort(dishes, sortDirection);
        }
    }
}