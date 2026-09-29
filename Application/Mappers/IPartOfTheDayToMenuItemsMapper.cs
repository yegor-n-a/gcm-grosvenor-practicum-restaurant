using Application.Models;
using System.Collections.Generic;

namespace Application.Mappers
{
    public interface IPartOfTheDayToMenuItemsMapper : IDishMapper<PartOfTheDay, IDictionary<int, DishName>> { }
}
