using System.Collections.Generic;

namespace Application.Mappers
{
    public abstract class DishMapper<TSource, TDestination> : IDishMapper<TSource, TDestination>
    {
        public abstract IDictionary<TSource, TDestination> Mappings { get; }

        public virtual TDestination Map(TSource source)
        {
            var success = Mappings.TryGetValue(source, out var value);

            return success
                ? value
                : default;
        }

        protected DishMapper() { }
    }
}
