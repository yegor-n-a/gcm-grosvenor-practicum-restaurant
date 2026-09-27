using Ardalis.SmartEnum;
using System;

namespace Application.Resolvers
{
    public interface IDishResolver<TModel, TSource> : IResolver<TModel, TSource>
        where TModel : SmartEnum<TModel, TSource>
        where TSource : IEquatable<TSource>, IComparable<TSource>
    { }
}
