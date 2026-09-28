using Application.Extensions;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Models
{
    public class Menu
    {
        public ImmutableDictionary<int, string> Items { get; }

        public Menu(IDictionary<int, string> items)
        {
            Items = items.IsNullOrEmpty()
                ? ImmutableDictionary<int, string>.Empty
                : items.ToImmutableDictionary();
        }
    }
}
