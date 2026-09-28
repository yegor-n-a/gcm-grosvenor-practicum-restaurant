using Application.Constraints;
using Application.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Mappers
{
    public class DishNameToConstraintsMapper : DishMapper<DishName, DishConstraints>, IDishNameToConstraintsMapper
    {
        public override IDictionary<DishName, DishConstraints> Mappings { get; } = ImmutableDictionary.CreateRange(
            new Dictionary<DishName, DishConstraints>
            {
                { DishName.Egg, new DishConstraints { MaxCountAllowed = 1 } },
                { DishName.Steak, new DishConstraints { MaxCountAllowed = 1 } },
                { DishName.Toast, new DishConstraints { MaxCountAllowed = 1 } },
                { DishName.Potato, new DishConstraints { MaxCountAllowed = null } },
                { DishName.Coffee, new DishConstraints { MaxCountAllowed = null } },
                { DishName.Wine, new DishConstraints { MaxCountAllowed = 1 } },
                { DishName.Cake, new DishConstraints { MaxCountAllowed = 1 } }
            });
    }
}
