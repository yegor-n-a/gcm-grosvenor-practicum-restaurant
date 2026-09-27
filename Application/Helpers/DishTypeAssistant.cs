using Application.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Helpers
{
    public static class DishTypeAssistant
    {
        private static bool IgnoreCase { get; } = true;

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
            type = type?.Trim();

            if (string.IsNullOrWhiteSpace(type)) return DishType.None;

            var success = DishType.TryFromName(type, IgnoreCase, out var typeValue);

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
