using System.Collections.Immutable;

namespace Application.Models
{
    public interface IOrder<T>
    {
        public ImmutableArray<T> Dishes { get; }
    }
}
