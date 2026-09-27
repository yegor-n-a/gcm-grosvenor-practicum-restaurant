using Application.Interfaces.General;
using Ardalis.SmartEnum;
using System;
using System.Linq;

namespace Application.Resolvers
{
    public class DishResolver<TModel, TSource> : StringResolver<TModel>, IDishResolver<TModel, TSource>
        where TModel : SmartEnum<TModel, TSource>, IDefaultPrimitive<TModel>
        where TSource : IEquatable<TSource>, IComparable<TSource>
    {
        protected TModel Default => SmartEnum<TModel, TSource>.List.First().Default;

        public TModel Resolve(TSource source)
        {
            var success = SmartEnum<TModel, TSource>.TryFromValue(source, out var value);

            return success
                ? value
                : Default;
        }

        public override TModel Resolve(string name)
        {
            name = name?.Trim();

            if (string.IsNullOrWhiteSpace(name)) return Default;

            var success = SmartEnum<TModel, TSource>.TryFromName(name, IgnoreCase, out var value);

            return success
                ? value
                : Default;
        }
    }
}
