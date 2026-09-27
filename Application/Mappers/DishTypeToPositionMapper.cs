using Application.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Mappers
{
    public class DishTypeToPositionMapper : DishMapper<DishType, decimal>, IDishTypeToPositionMapper
    {
        public override IDictionary<DishType, decimal> Mappings { get; } = ImmutableDictionary.CreateRange(
            new Dictionary<DishType, decimal>
            {
                { DishType.Entree, 1 },
                { DishType.Side, 2 },
                { DishType.Drink, 3 },
                { DishType.Dessert, 4 }
            });
    }
}
