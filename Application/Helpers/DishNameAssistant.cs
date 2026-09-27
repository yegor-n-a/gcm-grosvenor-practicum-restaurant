using Application.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Helpers
{
    public static class DishNameAssistant
    {
        private static bool IgnoreCase { get; } = true;

        public static ImmutableDictionary<DishName, DishType> DishNamesToTypesMapping { get; } = ImmutableDictionary.CreateRange(
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

        public static DishName GetName(string name)
        {
            name = name?.Trim();

            if (string.IsNullOrWhiteSpace(name)) return DishName.None;

            var success = DishName.TryFromName(name, IgnoreCase, out var nameValue);

            return success
                ? nameValue
                : DishName.None;
        }

        public static DishType GetType(DishName name)
        {
            var success = DishNamesToTypesMapping.TryGetValue(name, out var type);

            return success
                ? type
                : DishType.None;
        }

        public static DishType GetType(string name)
        {
            var dishName = GetName(name);

            return GetType(dishName);
        }
    }
}
