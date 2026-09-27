using Application.Models;
using Ardalis.SmartEnum;

namespace Application.Resolvers
{
    public interface IDishResolver<TModel, TSource> : IResolver<TModel, TSource>//, IStringResolver<TModel>
        where TModel : SmartEnum<TModel>
    { }

    public class DishResolver : StringResolver<DishName>, IDishNameResolver
    {
        public DishName Resolve(int valueId)
        {
            var success = DishName.TryFromValue(valueId, out var value);

            return success
                ? value
                : DishName.None;
        }

        public override DishName Resolve(string valueName)
        {
            valueName = valueName?.Trim();

            if (string.IsNullOrWhiteSpace(valueName)) return DishName.None;

            var success = DishName.TryFromName(valueName, IgnoreCase, out var value);

            return success
                ? value
                : DishName.None;
        }
    }

    public class DishNameResolver : StringResolver<DishName>, IDishNameResolver
    {
        public DishName Resolve(int valueId)
        {
            var success = DishName.TryFromValue(valueId, out var value);

            return success
                ? value
                : DishName.None;
        }

        public override DishName Resolve(string valueName)
        {
            valueName = valueName?.Trim();

            if (string.IsNullOrWhiteSpace(valueName)) return DishName.None;

            var success = DishName.TryFromName(valueName, IgnoreCase, out var value);

            return success
                ? value
                : DishName.None;
        }
    }
}
