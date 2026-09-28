using Application.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Mappers
{
    public class PartOfTheDayToMenuItemsMapper : DishMapper<PartOfTheDay, ImmutableList<int>>, IPartOfTheDayToMenuItemsMapper
    {
        public override IDictionary<PartOfTheDay, ImmutableList<int>> Mappings { get; } = ImmutableDictionary.CreateRange(
            new Dictionary<PartOfTheDay, ImmutableList<int>>
            {
                { PartOfTheDay.Morning,
                    ImmutableList.Create(
                        DishName.Egg.Value,
                        DishName.Toast.Value,
                        DishName.Coffee.Value)
                },
                { PartOfTheDay.Evening,
                    ImmutableList.Create(
                        DishName.Steak.Value,
                        DishName.Potato.Value,
                        DishName.Wine.Value,
                        DishName.Cake.Value)
                }
            });
    }
}
