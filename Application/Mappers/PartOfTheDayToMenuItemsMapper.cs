using Application.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Mappers
{
    public class PartOfTheDayToMenuItemsMapper : DishMapper<PartOfTheDay, IDictionary<int, string>>, IPartOfTheDayToMenuItemsMapper
    {
        public override IDictionary<PartOfTheDay, IDictionary<int, string>> Mappings { get; } = ImmutableDictionary.CreateRange(
            new Dictionary<PartOfTheDay, IDictionary<int, string>>
            {
                { PartOfTheDay.Morning,
                    new Dictionary<int, string>
                    {
                        { DishName.Egg.Value, DishName.Egg.Name },
                        { DishName.Toast.Value, DishName.Toast.Name },
                        { DishName.Coffee.Value, DishName.Coffee.Name }
                    }
                },
                { PartOfTheDay.Evening,
                    new Dictionary<int, string>
                    {
                        { DishName.Steak.Value, DishName.Steak.Name },
                        { DishName.Potato.Value, DishName.Potato.Name },
                        { DishName.Wine.Value, DishName.Wine.Name },
                        { DishName.Cake.Value, DishName.Cake.Name }
                    }
                }
            });
    }
}
