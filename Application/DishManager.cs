using Application.Models;
using Application.Models.General;
using Application.Sorters;
using Application.Validators;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

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
                    var validationErrors = string.Join("; ", validatedDish.Errors.Select(error => error.ErrorMessage));

                    throw new ApplicationException($"Dish '{dish.Name}' failed validation: {validationErrors}");
                }
                else
                {
                    yield return dish;
                }
            }
        }

        public ImmutableArray<Dish> SortDishes(IEnumerable<Dish> dishes, SortDirection sortDirection)
        {
            return DishSorter.Sort(dishes, sortDirection);
        }
    }
}