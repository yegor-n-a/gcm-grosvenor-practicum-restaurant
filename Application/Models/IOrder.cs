using System.Collections.Immutable;

namespace Application.Models
{
    public interface IOrder<T>
    {
        public ImmutableSortedSet<T> Dishes { get; }
    }
}
