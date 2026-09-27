using Application.Models;

namespace Application.Resolvers
{
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
