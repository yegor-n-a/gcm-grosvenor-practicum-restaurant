using Application.Models;

namespace Application.Resolvers
{
    public interface IDishNameResolver : IResolver<DishName, int>, IStringResolver<DishName> { }
}
