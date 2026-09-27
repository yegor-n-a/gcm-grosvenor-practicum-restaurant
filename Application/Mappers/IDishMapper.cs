using System.Collections.Generic;

namespace Application.Mappers
{
    public interface IDishMapper<TSource, TDestination> : IMapper<TSource, TDestination>
    {
        public IDictionary<TSource, TDestination> Mappings { get; }
    }
}
