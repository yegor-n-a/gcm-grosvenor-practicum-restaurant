using Application.Models;

namespace Application.Resolvers
{
    public class DishTypeResolver : StringResolver<DishType>, IDishTypeResolver
    {
        public override DishType Resolve(string name)
        {
            name = name?.Trim();

            if (string.IsNullOrWhiteSpace(name)) return DishType.None;

            var success = DishType.TryFromName(name, IgnoreCase, out var nameValue);

            return success
                ? nameValue
                : DishType.None;
        }
    }
}
