using Application.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Helpers
{
    public static class DishTypeAssistant
    {
        public static ImmutableDictionary<string, DishType> DishTypesMapping { get; } = ImmutableDictionary.CreateRange(
            StringComparer.OrdinalIgnoreCase,
            new Dictionary<string, DishType>
            {
                { DishType.Entree.Name, DishType.Entree },
                { DishType.Side.Name, DishType.Side },
                { DishType.Drink.Name, DishType.Drink },
                { DishType.Dessert.Name, DishType.Dessert }
            });

        public static ImmutableDictionary<DishType, decimal> DishTypePositions { get; } = ImmutableDictionary.CreateRange(
            new Dictionary<DishType, decimal>
            {
                { DishType.Entree, 1 },
                { DishType.Side, 2 },
                { DishType.Drink, 3 },
                { DishType.Dessert, 4 }
            });

        public static DishType GetType(string type)
        {
            type = type?.Trim().ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(type)) return DishType.None;

            var success = DishTypesMapping.TryGetValue(type, out var typeValue);

            return success
                ? typeValue
                : DishType.None;
        }

        public static decimal? GetPosition(DishType type)
        {
            var success = DishTypePositions.TryGetValue(type, out var position);

            return success
                ? position
                : default;
        }

        public static decimal? GetPosition(string type)
        {
            var dishType = GetType(type);

            return GetPosition(dishType);
        }
    }
}
