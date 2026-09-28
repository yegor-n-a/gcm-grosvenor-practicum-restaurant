using Application.Models;
using System.Collections.Generic;

namespace Application.Printers
{
    public interface IDishPrinter
    {
        string Print(IEnumerable<Dish> dishes);
    }
}
