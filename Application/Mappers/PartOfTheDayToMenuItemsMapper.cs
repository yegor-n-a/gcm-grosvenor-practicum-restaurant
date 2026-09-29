using Application.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Mappers
{
    public class PartOfTheDayToMenuItemsMapper : DishMapper<PartOfTheDay, IDictionary<int, DishName>>, IPartOfTheDayToMenuItemsMapper
    {
        public override IDictionary<PartOfTheDay, IDictionary<int, DishName>> Mappings { get; } = ImmutableDictionary.CreateRange(
            new Dictionary<PartOfTheDay, IDictionary<int, DishName>>
            {
                { PartOfTheDay.Morning,
                    new Dictionary<int, DishName>
                    {
                        { 1, DishName.Egg },
                        { 2, DishName.Toast },
                        { 3, DishName.Coffee }
                    }
                },
                { PartOfTheDay.Evening,
                    new Dictionary<int, DishName>
                    {
                        { 1, DishName.Steak },
                        { 2, DishName.Potato },
                        { 3, DishName.Wine },
                        { 4, DishName.Cake }
                    }
                }
            });
    }
}
