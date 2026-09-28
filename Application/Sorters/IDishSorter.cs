using Application.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Sorters
{
    public interface IDishSorter : ISorter<IEnumerable<Dish>, ImmutableSortedSet<Dish>>
    { }
}
