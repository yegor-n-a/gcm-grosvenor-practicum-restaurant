using Application.Models;
using System.Collections.Generic;
using System.Linq;

namespace Application.Printers
{
    public class DishPrinter : IDishPrinter
    {
        public string Print(IEnumerable<Dish> dishes)
        {
            return string.Join(",", dishes.Select(dish => $"{dish.Name.Name.ToLowerInvariant()}{GetMultiple(dish.Count)}"));
        }

        private string GetMultiple(int count)
        {
            return count > 1
                ? $"(x{count})"
                : string.Empty;
        }
    }
}
