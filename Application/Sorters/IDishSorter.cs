using System.Collections.Generic;
using Application.Models;
using System.Collections.Immutable;

namespace Application.Sorters
{
    public interface IDishSorter : ISorter<IEnumerable<_Dish>, ImmutableSortedSet<_Dish>>
    { }
}
