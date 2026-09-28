using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Sorters
{
    public interface IOrderSorter<T> : ISorter<IEnumerable<T>, ImmutableSortedSet<T>>
    { }
}
