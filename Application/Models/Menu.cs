using Application.Extensions;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Models
{
    public class Menu
    {
        public ImmutableDictionary<int, DishName> Items { get; }

        public Menu(IDictionary<int, DishName> items)
        {
            Items = items.IsNullOrEmpty()
                ? ImmutableDictionary<int, DishName>.Empty
                : items.ToImmutableDictionary();
        }
    }
}
