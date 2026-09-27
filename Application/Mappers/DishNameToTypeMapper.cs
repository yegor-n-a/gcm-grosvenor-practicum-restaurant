using Application.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Mappers
{
    public class DishNameToTypeMapper : DishMapper<DishName, DishType>, IDishNameToTypeMapper
    {
        public override IDictionary<DishName, DishType> Mappings { get; } = ImmutableDictionary.CreateRange(
            new Dictionary<DishName, DishType>
            {
                { DishName.Egg, DishType.Entree },
                { DishName.Steak, DishType.Entree },
                { DishName.Toast, DishType.Side },
                { DishName.Potato, DishType.Side },
                { DishName.Coffee, DishType.Drink },
                { DishName.Wine, DishType.Drink },
                { DishName.Cake, DishType.Dessert }
            });
    }
}
