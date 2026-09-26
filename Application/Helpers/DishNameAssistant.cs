using Application.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Helpers
{
    public static class DishNameAssistant
    {
        public static ImmutableDictionary<string, DishName> DishNamesMapping { get; } = ImmutableDictionary.CreateRange(
            StringComparer.OrdinalIgnoreCase,
            new Dictionary<string, DishName>
            {
                { DishName.Egg.Name, DishName.Egg },
                { DishName.Steak.Name, DishName.Steak },
                { DishName.Toast.Name, DishName.Toast },
                { DishName.Potato.Name, DishName.Potato },
                { DishName.Coffee.Name, DishName.Coffee },
                { DishName.Wine.Name, DishName.Wine },
                { DishName.Cake.Name, DishName.Cake }
            });

        public static ImmutableDictionary<string, DishType> DishNamesToTypesMapping { get; } = ImmutableDictionary.CreateRange(
            StringComparer.OrdinalIgnoreCase,
            new Dictionary<string, DishType>
            {
                { DishName.Egg.Name, DishType.Entree },
                { DishName.Steak.Name, DishType.Entree },
                { DishName.Toast.Name, DishType.Side },
                { DishName.Potato.Name, DishType.Side },
                { DishName.Coffee.Name, DishType.Drink },
                { DishName.Wine.Name, DishType.Drink },
                { DishName.Cake.Name, DishType.Dessert }
            });

        public static DishName GetName(string name)
        {
            name = name?.Trim().ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(name)) return DishName.None;

            var success = DishNamesMapping.TryGetValue(name, out var nameValue);

            return success
                ? nameValue
                : DishName.None;
        }

        public static DishType GetType(DishName name)
        {
            return GetType(name.Name);
        }

        public static DishType GetType(string name)
        {
            name = name?.Trim().ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(name)) return DishType.None;

            var success = DishNamesToTypesMapping.TryGetValue(name, out var type);

            return success
                ? type
                : DishType.None;
        }
    }
}
