using Application.Models;
using System.Collections.Immutable;

namespace Application.Mappers
{
    public interface IPartOfTheDayToMenuItemsMapper : IDishMapper<PartOfTheDay, ImmutableList<int>> { }
}
