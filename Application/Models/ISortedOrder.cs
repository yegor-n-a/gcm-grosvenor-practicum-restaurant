using System.Collections.Immutable;

namespace Application.Models
{
    public interface ISortedOrder<T>
    {
        public ImmutableSortedSet<T> Dishes { get; }
    }
}
